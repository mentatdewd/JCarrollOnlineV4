using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jcarrollonlinev4.backend.Entities;
using jcarrollonlinev4.backend.Models.Blog;
using Omu.ValueInjecter;

namespace JCarrollOnlinev4.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BlogController : Controller
    {
        private JCarrollOnlineV4DbContext _jCarrollOnlineV4DbContext { get; set; }

        public BlogController(JCarrollOnlineV4DbContext dataContext)
        {
            _jCarrollOnlineV4DbContext = dataContext;
        }

        // GET: BlogItemId
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            BlogIndexModel blogIndexViewModel = new BlogIndexModel();

            string currentUserId = User.Identity.Name;
            ApplicationUser? user = await _jCarrollOnlineV4DbContext.ApplicationUser.FindAsync(currentUserId).ConfigureAwait(false);
            List<BlogItem> blogItems = await _jCarrollOnlineV4DbContext.BlogItem.Include("BlogItemComments").ToListAsync().ConfigureAwait(false);

            foreach(BlogItem blogItem in blogItems.OrderByDescending(m => m.UpdatedAt))
            {
                BlogFeedItemModel blogFeedItemModel = new BlogFeedItemModel();

                blogFeedItemModel.InjectFrom(blogItem);
                blogFeedItemModel.Author.InjectFrom(blogItem.Author);

                foreach(BlogItemComment blogItemComment in blogItem.BlogItemComments.ToList())
                {
                    BlogCommentItemModel blogCommentItemViewModel = new BlogCommentItemModel(blogItem.Id);

                    blogCommentItemViewModel.InjectFrom(blogItemComment);
                    blogCommentItemViewModel.TimeAgo = blogCommentItemViewModel.CreatedAt.ToUniversalTime().ToString("o");
                    blogFeedItemModel.Comments.BlogComments.Add(blogCommentItemViewModel);
                }

                blogIndexViewModel.BlogFeedItems.BlogFeedItemModels.Add(blogFeedItemModel);               
            }

            return View(blogIndexViewModel);
        }

        // GET: BlogItemId/Details/5
        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        // POST: BlogItemComment/CreateComment
        [HttpPost]
        public void CreateComment(BlogCommentItemModel blogCommentItemModel)
        {
            if(ModelState.IsValid)
            {
                BlogItemComment blogItemComment = new BlogItemComment();

                blogItemComment.InjectFrom(blogCommentItemModel);
                blogItemComment.CreatedAt = DateTime.Now;

                if (blogCommentItemModel != null)
                {
                    blogItemComment.BlogItem = _jCarrollOnlineV4DbContext.BlogItem.Find(blogCommentItemModel.Id);
                }
                _jCarrollOnlineV4DbContext.BlogItemComment.Add(blogItemComment);
                _jCarrollOnlineV4DbContext.SaveChanges();
            }
        }

        // GET: BlogItemId/Create
        [HttpGet]
        public ActionResult Create()
        {
            BlogFeedItemModel blogFeedItemModel = new BlogFeedItemModel();

            return View(blogFeedItemModel);
        }

        // POST: BlogItemId/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        [Authorize(Roles = "Administrator")]
#pragma warning disable CA5363 // Do Not Disable Request Validation
        public async Task<ActionResult> Create(/*[Bind(Include = "Title,Content")]*/  BlogFeedItemModel blogFeedItemModel)
#pragma warning restore CA5363 // Do Not Disable Request Validation
        {
            if (ModelState.IsValid)
            {
                BlogItem blogItem = new BlogItem();

                blogItem.InjectFrom(blogFeedItemModel);

                blogItem.CreatedAt = DateTime.Now;
                blogItem.UpdatedAt = DateTime.Now;

                string currentUserId = User.Identity.Name;
                ApplicationUser currentUser = await _jCarrollOnlineV4DbContext.ApplicationUser.FirstOrDefaultAsync(x => x.Id == currentUserId).ConfigureAwait(false);

                blogItem.Author = currentUser;

                _jCarrollOnlineV4DbContext.BlogItem.Add(blogItem);
                await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

                return new RedirectResult(Url.Action("Index"));
            }

            return View(blogFeedItemModel);
        }

        // GET: BlogItemId/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int blogItemId)
        {
            BlogFeedItemModel blogFeedItemModel = new BlogFeedItemModel();

            BlogItem? blogItem = await _jCarrollOnlineV4DbContext.BlogItem.Include("Author").SingleOrDefaultAsync(m => m.Id == blogItemId).ConfigureAwait(false);

            blogFeedItemModel.InjectFrom(blogItem);
            blogFeedItemModel.Author.InjectFrom(blogItem?.Author);
            blogFeedItemModel.AuthorId = blogFeedItemModel.Author.Id;

            return View(blogFeedItemModel);
        }

        // POST: BlogItemId/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(/*[Bind(Include = "Id,AuthorId,Title,Content,CreatedAt")]*/ BlogFeedItemModel blogItemModel)
        {
            if (ModelState.IsValid)
            {
                BlogItem blogItem = new BlogItem();

                blogItem.InjectFrom(blogItemModel);
                if (blogItemModel != null)
                {
                    blogItem.Author = await _jCarrollOnlineV4DbContext.ApplicationUser.FindAsync(blogItemModel.AuthorId).ConfigureAwait(false);
                }
                blogItem.UpdatedAt = DateTime.Now;

                _jCarrollOnlineV4DbContext.Entry(blogItem).State = EntityState.Modified;
                await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

                //return Redirect(Url.RouteUrl(new { controller = "Blog", action = "Index"}));
            }

            return View(blogItemModel);
        }

        // GET: BlogItemId/Delete/5
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        //// POST: BlogItemId/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete()
        //{
        //    // TODO: Add delete logic here
        //    return RedirectToAction("Index");
        //}
    }
}
