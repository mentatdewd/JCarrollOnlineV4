using jcarrollonlinev4.backend.Entities;
using jcarrollonlinev4.backend.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;

namespace jcarrollonlinev4.backend.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        //private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly JCarrollOnlineV4DbContext _jCarrollOnlineV4DbContext;

        public UsersController(JCarrollOnlineV4DbContext dataContext)
        {
            _jCarrollOnlineV4DbContext = dataContext;
        }

        // GET: Users
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            UsersIndexModel usersIndexViewModel = new UsersIndexModel
            {
                PageTitle = "Users"
            };

            System.Collections.Generic.List<ApplicationUser> users = await _jCarrollOnlineV4DbContext.ApplicationUser.Include("Following").Include("Followers").ToListAsync().ConfigureAwait(false);

            foreach (ApplicationUser user in users)
            {
                UserItemModel userItemViewModel = new UserItemModel();

                userItemViewModel.User.InjectFrom(user);
                userItemViewModel.MicropostsAuthored = await _jCarrollOnlineV4DbContext.ApplicationUser.Include("MicroPosts").Where(u => u.Id == user.Id).Select(u => u.Microposts).CountAsync().ConfigureAwait(false);
                usersIndexViewModel.Users.Add(userItemViewModel);
            }

            return View(usersIndexViewModel);
        }

        // GET: Users/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(string userId)
        {
            UserDetailModel userDetailModel = new UserDetailModel();

            string currentUserId = "";// = User.Identity.GetUserId();
            
            if(userId == null)
            {
                userId = currentUserId;
            }

            ApplicationUser? currentUser = await _jCarrollOnlineV4DbContext.ApplicationUser.FirstOrDefaultAsync(x => x.Id == currentUserId).ConfigureAwait(false);
            ApplicationUser? user = await _jCarrollOnlineV4DbContext.ApplicationUser.Include("Following").Include("Followers").FirstOrDefaultAsync(m => m.Id == userId).ConfigureAwait(false);

            if (user != null)
            {
                userDetailModel.UserInfoModel.User.InjectFrom(user);

                userDetailModel.UserInfoModel.MicropostEmailNotifications = user.MicroPostEmailNotifications;
                //udVM.UserInfoVM.MicroPostSMSNotifications = user.MicroPostSMSNotifications;
                userDetailModel.UserInfoModel.UserId = currentUserId;

                userDetailModel.UserStatsModel = new UserStatsModel
                {
                    UsersFollowing = new UserFollowingModel()
                };

                userDetailModel.UserStatsModel.User.InjectFrom(user);

                foreach (ApplicationUser following in user.Following)
                {
                    UserItemModel userItemViewModel = new UserItemModel();

                    userItemViewModel.User.InjectFrom(following);
                    userItemViewModel.UserId = following.Id;
                    userItemViewModel.MicropostsAuthored = await _jCarrollOnlineV4DbContext.Micropost.Where(u => u.Author.Id == following.Id).CountAsync().ConfigureAwait(false);
                    userDetailModel.UserStatsModel.UsersFollowing.Users.Add(userItemViewModel);
                }

                userDetailModel.UserStatsModel.UserFollowers = new UserFollowersModel();

                foreach (ApplicationUser follower in user.Followers)
                {
                    UserItemModel userItemModel = new UserItemModel();

                    userItemModel.User.InjectFrom(follower);
                    userItemModel.UserId = follower.Id;
                    userItemModel.MicropostsAuthored = await _jCarrollOnlineV4DbContext.Micropost.Where(u => u.Author.Id == follower.Id).CountAsync().ConfigureAwait(false);
                    userDetailModel.UserStatsModel.UserFollowers.Users.Add(userItemModel);
                }
            }
            return View(userDetailModel);
        }

        [HttpGet]
        public async Task<ActionResult> Following(string userId)
        {
            UserDetailModel userDetailModel = new UserDetailModel
            {
                PageTitle = "Following",
                UserInfoModel = new UserItemModel()
            };

            ApplicationUser user = await _jCarrollOnlineV4DbContext.ApplicationUser.Include("Following").Include("Followers").SingleAsync(m => m.Id == userId).ConfigureAwait(false);

            userDetailModel.UserStatsModel = new UserStatsModel();
            userDetailModel.User.InjectFrom(user);
            userDetailModel.UserInfoModel.User.InjectFrom(user);
            userDetailModel.UserStatsModel.User.InjectFrom(user);

            foreach (ApplicationUser following in user.Following)
            {
                UserItemModel userItemModel = new UserItemModel();
                userItemModel.User.InjectFrom(following);
                userItemModel.MicropostsAuthored = following.Microposts.Count;
                userDetailModel.UserStatsModel.UsersFollowing.Users.Add(userItemModel);
            }

            foreach (ApplicationUser follower in user.Followers)
            {
                UserItemModel userItemModel = new UserItemModel();
                userItemModel.InjectFrom(follower);
                userItemModel.MicropostsAuthored = follower.Microposts.Count;
                userDetailModel.UserStatsModel.UserFollowers.Users.Add(userItemModel);
            }

            return View("Show_Follow", userDetailModel);
        }

        [HttpGet]
        public async Task<ActionResult> Followed(string userId)
        {
            UserDetailModel userDetailModel = new UserDetailModel
            {
                PageTitle = "Followers",
                UserInfoModel = new UserItemModel()
            };

            ApplicationUser user = await _jCarrollOnlineV4DbContext.ApplicationUser.Include("Following").Include("Followers").SingleAsync(m => m.Id == userId).ConfigureAwait(false);

            userDetailModel.UserStatsModel = new UserStatsModel();
            userDetailModel.User.InjectFrom(user);
            userDetailModel.UserInfoModel.User.InjectFrom(user);
            userDetailModel.UserStatsModel.User.InjectFrom(user);

            foreach (ApplicationUser following in user.Following)
            {
                UserItemModel userItemModel = new UserItemModel();

                userItemModel.User.InjectFrom(following);
                userItemModel.MicropostsAuthored = following.Microposts.Count;
                userDetailModel.UserStatsModel.UsersFollowing.Users.Add(userItemModel);
            }

            foreach (ApplicationUser follower in user.Followers)
            {
                UserItemModel userItemModel = new UserItemModel();

                userItemModel.User.InjectFrom(follower);
                userItemModel.MicropostsAuthored = follower.Microposts.Count;
                userDetailModel.UserStatsModel.UserFollowers.Users.Add(userItemModel);
            }

            return View("Show_Follow", userDetailModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Follow(/*[Bind(Include = "UserId")]*/  UserItemModel followUser)
        {

            if (ModelState.IsValid)
            {
                string? currentUserId = User.Identity?.Name;
                ApplicationUser? currentUser = await _jCarrollOnlineV4DbContext.ApplicationUser.FirstOrDefaultAsync(x => x.Id == currentUserId).ConfigureAwait(false);
                ApplicationUser? followingUser = await _jCarrollOnlineV4DbContext.ApplicationUser.FirstOrDefaultAsync(x => x.Id == followUser.UserId).ConfigureAwait(false);

                currentUser?.Following?.Add(followingUser);
                await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);
            }

            return RedirectToAction("Details", new { userid = followUser?.UserId });
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Unfollow")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Unfollow(/*[Bind(Include = "UserId")]*/  UserItemModel followUser)
        {

            if (ModelState.IsValid)
            {
                string? currentUserId = User.Identity?.Name;
                ApplicationUser? currentUser = await _jCarrollOnlineV4DbContext.ApplicationUser.FirstOrDefaultAsync(x => x.Id == currentUserId).ConfigureAwait(false);
                ApplicationUser? followingUser = await _jCarrollOnlineV4DbContext.ApplicationUser.FirstOrDefaultAsync(x => x.Id == followUser.UserId).ConfigureAwait(false);

                currentUser?.Following?.Remove(followingUser);
                await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);
            }

            return RedirectToAction("Details", new { userid = followUser?.UserId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UserSettings(/*[Bind(Include = "UserId,MicroPostEmailNotifications,MicroPostSmsNotifications")]*/ UserItemModel userItemModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser? user = await _jCarrollOnlineV4DbContext.ApplicationUser.FirstOrDefaultAsync(x => x.Id == userItemModel.UserId).ConfigureAwait(false);

                if (userItemModel != null)
                {
                    //user?.MicropostEmailNotifications = userItemModel.MicropostEmailNotifications;
                    //user.MicroPostSMSNotifications = auVM.MicroPostSMSNotifications;
                    await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);
                }
            }

            return RedirectToAction("Details", new { userid = userItemModel?.UserId });
        }

        // GET: Users/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return await Task.Run<ActionResult>(() =>
            {
                return View();
            }).ConfigureAwait(false);

        }

        //// POST: Users/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create()
        //{
        //    return await Task.Run<ActionResult>(() =>
        //    {
        //        return RedirectToAction("Index");
        //    }).ConfigureAwait(false);
        //}

        // GET: Users/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit()
        {
            return await Task.Run<ActionResult>(() =>
            {
                return View();
            }).ConfigureAwait(false);
        }

        // POST: Users/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(int id, FormCollection collection)
        //{
        //    return await Task.Run<ActionResult>(() =>
        //    {
        //        return RedirectToAction("Index");
        //    }).ConfigureAwait(false);
        //}

        // GET: Users/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete()
        {
            return await Task.Run<ActionResult>(() =>
            {
                return View();
            }).ConfigureAwait(false);
        }

        // POST: Users/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete()
        //{
        //    return await Task.Run<ActionResult>(() =>
        //    {
        //        // TODO: Add delete logic here
        //        return RedirectToAction("Index");
        //    }).ConfigureAwait(false);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }

            base.Dispose(disposing);
        }
    }
}
