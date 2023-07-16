using AutoMapper;
using DAL.Models;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using JCarrollOnline.ViewModels;
using System.Linq;
using System.Collections.Generic;
using System;

namespace jcarrollonlinev4.backend.controllers
{
    [ApiController]
    [Route("api/fora/[controller]")]
    public class ForumThreads : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public ForumThreads(ApplicationDbContext dataContext, IMapper mapper, IUnitOfWork unitOfWork, ILogger logger)
        {
            _context = dataContext;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost("CreateForumThread")]
        public async Task<ActionResult<ForumThreadViewModel>> CreateForumThread([FromBody] ForumThreadViewModel forumThreadViewModel)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Forum> forumEntry;
            _logger.LogInformation("CreateForumThread");

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(forumThreadViewModel.Title) || string.IsNullOrEmpty(forumThreadViewModel.Content))
                {
                    return BadRequest(ModelState);
                }

                Forum forum = new Forum();

                _mapper.Map(forumThreadViewModel, forum);
                forum.CreatedAt = DateTime.Now;
                forum.UpdatedAt = DateTime.Now;
                forumEntry = _context.Fora.Add(forum);

                await _context.SaveChangesAsync().ConfigureAwait(false);

                if (forumEntry != null)
                {
                    return CreatedAtAction(nameof(CreateForumThread), new { id = forumEntry.Entity.Id }, forumThreadViewModel);
                }
                return BadRequest();
            }
            else { return BadRequest(); }
        }

        [HttpGet("GetForumThreads")]
        public ActionResult<List<ForumThreadsViewModel>> GetForumThreads()
        {
            if (ModelState.IsValid)
            {
                List<ForumThreadsViewModel> forumThreadEntries = new List<ForumThreadsViewModel>();

                return forumThreadEntries;
            }
            else { return BadRequest(); }
        }

        [HttpPost("DeleteForumThread")]
        public async Task<ActionResult<ForumThreadDeleteViewModel>> DeleteForumThread(int id)
        {
            if (ModelState.IsValid)
            {
                Forum forum = await _context.Fora.SingleOrDefaultAsync(x => x.Id == id);

                if (forum != null)
                {
                    _context.Fora.Remove(forum);
                    await _context.SaveChangesAsync().ConfigureAwait(false);

                    ForumThreadDeleteViewModel model = new ForumThreadDeleteViewModel();
                    //model.InjectFrom(forum);
                    return model;
                }
            }
            return BadRequest();
        }
    }
}
