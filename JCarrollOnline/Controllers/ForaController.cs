using AutoMapper;
using DAL;
using DAL.Models;
using JCarrollOnline.Helpers;
using JCarrollOnline.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JCarrollOnline.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ForaController(IMapper mapper,
            ApplicationDbContext context,
            IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            ILogger<MicropostController> logger/*, IEmailSender emailSender*/)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userManager = userManager;
            _context = context;
            //_emailSender = emailSender;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("CreateForum")]
        public async Task<ActionResult<ForaViewModel>> CreateForum([FromBody] ForaViewModel foraViewModel)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Forum> forumEntry;

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(foraViewModel.Title) || string.IsNullOrEmpty(foraViewModel.Description))
                {
                    return BadRequest(ModelState);
                }

                bool result = _context.Fora.Any(a => a.Title == foraViewModel.Title);
                if (result)
                {
                    return BadRequest(ModelState);
                }

                Forum forum = new Forum();

                _mapper.Map(foraViewModel, forum);
                forum.CreatedAt = DateTime.Now;
                forum.UpdatedAt = DateTime.Now;

                forumEntry = _context.Fora.Add(forum);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                if (forumEntry != null)
                {
                    _mapper.Map(forumEntry.Entity, foraViewModel);
                    return Ok(foraViewModel);
                }
                return BadRequest();
            }
            else { return BadRequest(); }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetAllFora")]
        public ActionResult<List<ForaViewModel>> GetAllFora()
        {
            if (ModelState.IsValid)
            {
                List<ForaViewModel> fora = new List<ForaViewModel>();

                foreach (Forum forum in _context.Fora)
                {
                    ForaViewModel foraModel = new ForaViewModel();

                    //foraModel.InjectFrom(forum);
                    _mapper.Map(forum, foraModel);
                    fora.Add(foraModel);
                }

                return fora;
            }
            else { return BadRequest(); }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetForum/{id?}")]
        public async Task<ActionResult<ForaViewModel>> GetForum(int id)
        {
            if (ModelState.IsValid)
            {
                ForaViewModel fora = new ForaViewModel();

                Forum forum = await _context.Fora.FirstOrDefaultAsync(f => f.Id == id);

                ForaViewModel forumModel = new ForaViewModel();

                _mapper.Map(forum, forumModel);

                return forumModel;
            }
            else { return BadRequest(); }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("DeleteForum")]
        public async Task<ActionResult<ForumViewModel>> DeleteForum(int id)
        {
            if (ModelState.IsValid)
            {
                Forum forum = await _context.Fora.SingleOrDefaultAsync(x => x.Id == id);

                if (forum != null)
                {
                    _context.Fora.Remove(forum);
                    await _context.SaveChangesAsync().ConfigureAwait(false);

                    ForumViewModel model = new ForumViewModel();
                    _mapper.Map(forum, model);

                    //model.InjectFrom(forum);
                    return model;
                }
            }
            return BadRequest();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetForumThreads")]
        public async Task<ActionResult<List<ForumThreadsViewModel>>> GetForumThreads(string forumId)
        {
            if (ModelState.IsValid)
            {
                List<ForumThreadsViewModel> forumThreadEntries = new List<ForumThreadsViewModel>();


                Forum forum = await _context.Fora.Include(f => f.ForumThreadEntries).ThenInclude(fte => fte.Author).FirstOrDefaultAsync(f => f.Id == int.Parse(forumId));

                if (forum != null)
                {
                    foreach (ForumThreadEntry fte in forum.ForumThreadEntries)
                    {
                        if (fte.ParentId == -1)
                        {
                            ForumThreadsViewModel forumThreadsViewModel = new ForumThreadsViewModel();

                            _mapper.Map(fte, forumThreadsViewModel);
                            forumThreadsViewModel.Replies = forum.ForumThreadEntries.Where(forumThreadEntry => forumThreadEntry.RootId == fte.Id && forumThreadEntry.ParentId != null).Count();
                            ForumThreadEntry lastUpdated = forum.ForumThreadEntries.Where(forumThreadEntry => forumThreadEntry.RootId == fte.Id).FirstOrDefault();

                            if (lastUpdated != null)
                            {
                                forumThreadsViewModel.LastReply = lastUpdated.UpdatedAt;
                            }
                            else
                            {
                                forumThreadsViewModel.LastReply = fte.UpdatedAt;
                            }
                            forumThreadEntries.Add(forumThreadsViewModel);
                        }

                    }
                }

                return forumThreadEntries;
            }
            return BadRequest();
        }


        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetForumThread")]
        public async Task<ActionResult<List<ForumThreadEntryViewModel>>> GetForumThread(int rootId)
        {
            if (ModelState.IsValid)
            {
                ForumThreadEntryViewModel forumThreadEntryViewModel = new ForumThreadEntryViewModel();

                ForumThreadEntry threadEntryTree = await _context.ForumThreads.Include(ft => ft.Children).Include(ft => ft.Author).Include(ft => ft.Parent).FirstOrDefaultAsync(ft => ft.Id == rootId);

                //var ep = _mapper.ConfigurationProvider.BuildExecutionPlan(typeof(ForumThreadEntry), typeof(ForumThreadEntryViewModel));

                _mapper.Map(threadEntryTree, forumThreadEntryViewModel);

                List<ForumThreadEntryViewModel> forumThreadEntryViewModels = new List<ForumThreadEntryViewModel>
                {
                    forumThreadEntryViewModel
                };
                return forumThreadEntryViewModels;
            }
            return BadRequest(ModelState);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetForumThreadEntry")]
        public async Task<ActionResult<ForumThreadEntryViewModel>> GetForumThreadEntry(int rootId)
        {
            if (ModelState.IsValid)
            {
                ForumThreadEntry threadEntry = await _context.ForumThreads.Include(ft => ft.Author).FirstOrDefaultAsync(ft => ft.Id == rootId);

                ForumThreadEntryViewModel forumThreadEntryViewModel = new ForumThreadEntryViewModel();

                _mapper.Map(threadEntry, forumThreadEntryViewModel);

                return forumThreadEntryViewModel;
            }
            return BadRequest(ModelState);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("ThreadCreate")]
        public async Task<ActionResult<ForumThreadEntryViewModel>> ThreadCreate([FromBody] ForumThreadEntryViewModel forumThreadViewModel)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<ForumThreadEntry> forumThreadEntry;

            if (ModelState.IsValid)
            {
                ApplicationUser application_user = await _userManager.GetUserAsync(HttpContext.User);

                if (application_user == null)
                {
                    Debug.WriteLine("User has not been acquired.");
                    return Unauthorized();
                }

                Forum forum = await _context.Fora.FirstOrDefaultAsync(f => f.Id == forumThreadViewModel.ForumId);
                if (forum == null)
                {
                    Debug.WriteLine("Bad forum id");
                    return BadRequest(ModelState);
                }

                if (string.IsNullOrEmpty(forumThreadViewModel.Title))
                {
                    return BadRequest(ModelState);
                }

                ForumThreadEntry forumThread = new ForumThreadEntry();

                _mapper.Map(forumThreadViewModel, forumThread);
                forumThread.CreatedAt = DateTime.Now;
                forumThread.UpdatedAt = DateTime.Now;
                forumThread.Author = application_user;
                forumThread.Forum = forum;
                forumThread.PostNumber = 1;
                forumThread.Locked = false;
                forumThread.RootId = -1;
                forumThread.ParentId = -1;

                forumThreadEntry = _context.ForumThreads.Add(forumThread);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                if (forumThreadEntry != null)
                {
                    _mapper.Map(forumThreadEntry.Entity, forumThreadViewModel);
                    forumThreadEntry.Entity.RootId = forumThreadViewModel.RootId = forumThreadEntry.Entity.Id;
                    forumThreadEntry.Entity.Author.ForumPostCount = forumThreadEntry.Entity.Author.ForumPostCount++;
                    _context.ForumThreads.Update(forumThreadEntry.Entity);
                    return Ok(forumThreadViewModel);
                }
                return BadRequest();
            }
            else { return BadRequest(); }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("ThreadReply")]
        public async Task<ActionResult<ForumThreadEntryViewModel>> ThreadReply([FromBody] ForumThreadEntryViewModel forumThreadEntryViewModel)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<ForumThreadEntry> forumThreadEntry;

            if (ModelState.IsValid)
            {
                ApplicationUser application_user = await _userManager.GetUserAsync(HttpContext.User);

                if (application_user == null)
                {
                    Debug.WriteLine("User has not been acquired.");
                    return Unauthorized();
                }

                Forum forum = await _context.Fora.FirstOrDefaultAsync(f => f.Id == forumThreadEntryViewModel.ForumId);
                if (forum == null)
                {
                    Debug.WriteLine("Bad forum id");
                    return BadRequest(ModelState);
                }

                if (string.IsNullOrEmpty(forumThreadEntryViewModel.Title))
                {
                    return BadRequest(ModelState);
                }

                ForumThreadEntry parentForumThreadEntry = await _context.ForumThreads.Include(ft => ft.Children).FirstOrDefaultAsync(ft => ft.Id == forumThreadEntryViewModel.ParentId);
                ForumThreadEntry forumThreadEntryEntity = new ForumThreadEntry();

                _mapper.Map(forumThreadEntryViewModel, forumThreadEntryEntity);
                forumThreadEntryEntity.CreatedAt = DateTime.Now;
                forumThreadEntryEntity.UpdatedAt = DateTime.Now;
                forumThreadEntryEntity.Author = application_user;
                forumThreadEntryEntity.Author.ForumPostCount = _context.ForumThreads.Where(o => o.Author == application_user).Count();
                forumThreadEntryEntity.Forum = forum;
                forumThreadEntryEntity.Locked = false;
                forumThreadEntryEntity.RootId = parentForumThreadEntry.RootId == -1 ? parentForumThreadEntry.Id : parentForumThreadEntry.RootId;
                IQueryable<ForumThreadEntry> records = _context.ForumThreads;
                forumThreadEntryEntity.PostNumber = records.Count(r => r.RootId == parentForumThreadEntry.RootId) + 1;

                forumThreadEntry = _context.ForumThreads.Add(forumThreadEntryEntity);

                parentForumThreadEntry.Children.Add(forumThreadEntryEntity);
                _context.ForumThreads.Update(parentForumThreadEntry);

                await _context.SaveChangesAsync().ConfigureAwait(false);
                if (forumThreadEntry != null)
                {
                    _mapper.Map(forumThreadEntry.Entity, forumThreadEntryViewModel);
                    //forumThreadEntryViewModel.AuthorPostCount = _context.ForumThreads.Where(o => o.Author == application_user).Count();
                    return Ok(forumThreadEntryViewModel);
                }
                return BadRequest();
            }
            return BadRequest();
        }
    }
}