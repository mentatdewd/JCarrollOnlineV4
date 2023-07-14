using AutoMapper;
using DAL;
using DAL.Models;
using JCarrollOnline.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JCarrollOnline.Controllers
{
    [Route("api/[controller]")]
    public class MicropostController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public MicropostController(IMapper mapper,
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

        public IActionResult Index()
        {
            return View();
        }

        // POST api/values
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("CreateMicropost")]
        public async Task<ActionResult<MicropostViewModel>> CreateMicropost([FromBody] string content)
        {
            ApplicationUser application_user = await _userManager.GetUserAsync(HttpContext.User);
            await _context.Entry(application_user).Collection(x => x.MicroPosts).LoadAsync();

            if (application_user == null)
            {
                Debug.WriteLine("User has not been acquired.");
                return Unauthorized();
            }
            Micropost micropost = new Micropost();

            micropost.Author = application_user;
            micropost.CreatedAt = DateTime.Now;
            micropost.UpdatedAt = DateTime.Now;
            micropost.Content = content;
            micropost.Author = application_user;

            _unitOfWork.Microposts.AddMicropost(application_user, micropost);
            _unitOfWork.SaveChanges();

            _logger.LogWarning("In MicropostController");
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetFollowedMicroposts")]
        public async Task<ActionResult<List<MicropostViewModel>>> GetFollowedMicroposts()
        {
            ApplicationUser application_user = await _userManager.GetUserAsync(HttpContext.User);

            // Get the users this user is following
            await _context.Entry(application_user).Collection(x => x.Following).LoadAsync();

            List<Micropost> microposts = new List<Micropost>();

            // Get the posts from each of the users this user is following
            foreach (ApplicationUser follow in application_user.Following)
            {
                microposts.AddRange(_context.Microposts.Where(a => a.Author.Id == follow.Id).ToList().OrderByDescending(a => a.CreatedAt));
            }

            // Add the users own posts
            microposts.AddRange(_context.Microposts.Where(a => a.Author.Id == application_user.Id).OrderByDescending(a => a.CreatedAt));

            List<MicropostViewModel> micropostViewModel = new List<MicropostViewModel>();

            _mapper.Map(microposts, micropostViewModel);

            return Ok(micropostViewModel);
        }

    }
}
