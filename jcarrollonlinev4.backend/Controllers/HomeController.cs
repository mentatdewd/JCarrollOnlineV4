using JCarrollOnlineV2.Controllers.Helpers;
using jcarrollonlinev4.backend.Entities;
using jcarrollonlinev4.backend.Models.Blog;
using jcarrollonlinev4.backend.Models.Home;
using jcarrollonlinev4.backend.Models.Micropost;
using jcarrollonlinev4.backend.Models.Rss;
using jcarrollonlinev4.backend.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;

namespace JCarrollOnlineV2.Controllers
{
    public class HomeController : Controller
    {
        //private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private JCarrollOnlineV4DbContext Data { get; set; }

        public HomeController(JCarrollOnlineV4DbContext context)
        {
           Data = context;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int? microPostPage)
        {
            //_logger.Info("In Home/Index");
            HomeModel homeModel = new HomeModel
            {
                Message = "JCarrollOnlineV2 Home - Index",
                MicropostCreateModel = new MicropostCreateModel(),
                MicropostFeedModel = new MicropostFeedModel(),
                UserStatsModel = new UserStatsModel(),
                UserInfoModel = new UserItemModel(),
                BlogFeed = new BlogFeedModel()
            };

            homeModel.UserStatsModel.UserFollowers = new UserFollowersModel();
            homeModel.UserStatsModel.UsersFollowing = new UserFollowingModel();

            //_logger.Info("Checking for blog entries");
            List<BlogItem> blogItems = await Data.BlogItem.Include("BlogItemComments").OrderByDescending(m => m.UpdatedAt).ToListAsync().ConfigureAwait(false);

            homeModel.LatestForumThreadsModel = new LatestForumThreadsModel();
            List<ThreadEntry> threads = await Data.ForumThreadEntry.Include(forumThreadEntry => forumThreadEntry.Forum).OrderByDescending(threadEntry => threadEntry.UpdatedAt).Take(5).ToListAsync().ConfigureAwait(false);

            foreach(ThreadEntry thread in threads)
            {
                LatestForumThreadItemModel latestForumThreadItemModel = new LatestForumThreadItemModel
                {
                    ThreadTitle = thread.Title,
                    ForumTitle = thread.Forum?.Title,
                    ForumId = thread.Forum.Id,
                    ThreadId = thread.Id
                };

                homeModel.LatestForumThreadsModel.LatestForumThreads.Add(latestForumThreadItemModel);
            }

            //_logger.Info("Processing blog entries");

            foreach (BlogItem item in blogItems)
            {
                BlogFeedItemModel blogFeedItemModel = new BlogFeedItemModel();

                blogFeedItemModel.InjectFrom(item);
                blogFeedItemModel.Comments.BlogItemId = item.Id;
                blogFeedItemModel.Author.InjectFrom(item.Author);

                foreach(BlogItemComment comment in item?.BlogItemComments?.ToList())
                {
                    BlogCommentItemModel blogCommentItemModel = new BlogCommentItemModel(item.Id);

                    blogCommentItemModel.InjectFrom(comment);
                    blogCommentItemModel.BlogItemId = comment.BlogItem.Id;
                    blogCommentItemModel.TimeAgo = blogCommentItemModel.CreatedAt.ToUniversalTime().ToString("o");
                    blogFeedItemModel.Comments.BlogComments.Add(blogCommentItemModel);
                }

                homeModel.BlogFeed.BlogFeedItemModels.Add(blogFeedItemModel);
            }

            //_logger.Info("Processing rss");

            Task<RssFeedModel> rss = ControllerHelpers.UpdateRssAsync();

            if (User != null && User.Identity?.IsAuthenticated == true)
            {
                string currentUserId = "currentuserid is unimplemented";
                ApplicationUser user = await Data.ApplicationUser.Include("Following").Include("Followers").Include("MicroPosts").SingleAsync(u => u.Id == currentUserId).ConfigureAwait(false);

                homeModel.UserInfoModel.User.InjectFrom(user);
                homeModel.UserInfoModel.UserId = user.Id;
                homeModel.UserInfoModel.MicropostsAuthored = user.Microposts?.Count;
                homeModel.UserStatsModel.User.InjectFrom(user);

                //_logger.Info("Processing followings");

                foreach (ApplicationUser item in user.Following)
                {
                    UserItemModel userItemModel = new UserItemModel();

                    userItemModel.InjectFrom(item);
                    homeModel.UserStatsModel.UsersFollowing.Users.Add(userItemModel);

                    foreach (Micropost microPost in item.Microposts)
                    {
                        MicropostFeedItemModel microPostFeedItemModel = new MicropostFeedItemModel();

                        microPostFeedItemModel.InjectFrom(microPost);
                        microPostFeedItemModel.Author?.InjectFrom(microPost.Author);
                        microPostFeedItemModel.TimeAgo = microPostFeedItemModel.CreatedAt.ToUniversalTime().ToString("o");
                        homeModel.MicropostFeedModel.MicroPostFeedItems.Add(microPostFeedItemModel);
                    }
                }

                //_logger.Info("Processing followers");

                foreach (ApplicationUser item in user.Followers)
                {
                    UserItemModel userItemModel = new UserItemModel();

                    userItemModel.InjectFrom(item);
                    userItemModel.MicropostsAuthored = await Data.ApplicationUser.Include("MicroPosts").Where(u => u.Id == item.Id).Select(u => u.Microposts).CountAsync().ConfigureAwait(false);
                    homeModel.UserStatsModel.UserFollowers.Users.Add(userItemModel);
                }

                //_logger.Info("Processing microPosts");

                foreach (Micropost micropost in user.Microposts)
                {
                    MicropostFeedItemModel micropostFeedItemModel = new MicropostFeedItemModel();

                    micropostFeedItemModel.InjectFrom(micropost);
                    micropostFeedItemModel.Author?.InjectFrom(micropost.Author);
                    micropostFeedItemModel.TimeAgo = micropostFeedItemModel.CreatedAt.ToUniversalTime().ToString("o");
                    homeModel.MicropostFeedModel.MicroPostFeedItems.Add(micropostFeedItemModel);
                }

                int micropostPageNumber = microPostPage ?? 1;

                //homeViewModel.MicroPostFeedModel.OnePageOfMicroPosts = homeViewModel.MicroPostFeedModel.MicroPostFeedItems.OrderByDescending(m => m.CreatedAt).ToPagedList(micropostPageNumber, 4);

                //_logger.Info("awaiting rss");
                homeModel.RssFeedModel = await rss.ConfigureAwait(false);
            }

            homeModel.PageContainer = "Home";
            //_logger.Info("Navigating to homepage");

            return View(homeModel);
        }

        [HttpGet]
        public ActionResult About()
        {
            AboutModel aboutModel = new AboutModel
            {
                Message = "About JCarrollOnlineV2",
                PageContainer = "AboutPage"
            };

            return View(aboutModel);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ContactModel contactModel = new ContactModel
            {
                Message = "JCarrollOnlineV2 Contact",
                PageContainer = "ContactPater"
            };

            return View(contactModel);
        }

        [HttpGet]
        public async Task<ActionResult> Welcome()
        {
            HomeModel homeModel = new HomeModel
            {
                Message = "JCarrollOnlineV2 Home - Welcome",
                PageContainer = "Welcome"
            };

            return await Task.Run<ActionResult>(() =>
            {
                return /*Request.IsAuthenticated ?*/ RedirectToAction("Index", "Home") /*: (ActionResult)View("Welcome", "_LayoutWelcome", homeModel)*/;
            }).ConfigureAwait(false);
        }
    }
}