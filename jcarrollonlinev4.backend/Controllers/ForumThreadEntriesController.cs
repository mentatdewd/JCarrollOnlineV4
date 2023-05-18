using jcarrollonlinev4.backend.Entities;
using jcarrollonlinev4.backend.Models.Fora;
using jcarrollonlinev4.backend.Models.ForumThreadEntries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;
using System.Net;

namespace JCarrollOnlineV2.Controllers
{

    public class ForumThreadEntriesController : Controller
    {
        private readonly JCarrollOnlineV4DbContext _jCarrollOnlineV4DbContext;

        public ForumThreadEntriesController(JCarrollOnlineV4DbContext dataContext)
        {
            _jCarrollOnlineV4DbContext = dataContext;
        }

        private void DetailItemInjector(ThreadEntry threadEntry, ThreadEntryDetailsItemModel threadEntryDetailsItemModel)
        {
            threadEntryDetailsItemModel.Author.InjectFrom(threadEntry.Author);
            threadEntryDetailsItemModel.Forum.InjectFrom(threadEntry.Forum);

            if (threadEntry.ParentId != null)
            {
                threadEntryDetailsItemModel.ParentPostNumber = _jCarrollOnlineV4DbContext.ForumThreadEntry.Find(threadEntry.ParentId).PostNumber;
            }

            threadEntryDetailsItemModel.PostCount = _jCarrollOnlineV4DbContext.ForumThreadEntry.Where(m => m.Author.Id == threadEntry.Author.Id).Count();
        }

        // GET: ForumOriginalPost
        [HttpGet]
        public async Task<ActionResult> Index(int forumId)
        {
            ThreadEntryIndexModel threadEntryIndexModel = new ThreadEntryIndexModel();

            // Retrieve forum data
            Forum currentForum = await _jCarrollOnlineV4DbContext.Forum
                .Include(forum => forum.ForumThreadEntries
                .Select(forumThreadEntry => forumThreadEntry.Author))              
                .FirstAsync(forum => forum.Id == forumId).ConfigureAwait(false);

            threadEntryIndexModel.Forum = new ForaModel();
            threadEntryIndexModel.Forum.InjectFrom(currentForum);

            // Create the view model

            foreach (ThreadEntry forumThread in currentForum.ForumThreadEntries.Where(forumThreadEntry => forumThreadEntry.ParentId == null))
            {
                ThreadEntryIndexItemModel threadEntryIndexItemModel = new ThreadEntryIndexItemModel();

                threadEntryIndexItemModel.InjectFrom(forumThread);
                threadEntryIndexItemModel.Forum.InjectFrom(currentForum);
                threadEntryIndexItemModel.Author.InjectFrom(forumThread.Author);
                
                threadEntryIndexItemModel.Replies = currentForum.ForumThreadEntries.Where(forumThreadEntry => forumThreadEntry.RootId == forumThread.Id && forumThreadEntry.ParentId != null).Count();
                threadEntryIndexItemModel.LastReply = currentForum.ForumThreadEntries.Where(m => m.RootId == forumThread.Id).OrderBy(m => m.UpdatedAt.ToFileTime()).FirstOrDefault().UpdatedAt;
                threadEntryIndexModel.ThreadEntryIndex.Add(threadEntryIndexItemModel);
            }

            return View(threadEntryIndexModel);
        }

        // GET: ForumOriginalPost/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int forumId, int? id)
        {
            // Retreive the Detail data
            if (id == null)
            {
                return RedirectToAction("index", routeValues: new {  forumId });
            }

            //IEnumerableExtensions.InjectorDelegate<ThreadEntry, ThreadEntryDetailsItemModel> detailItemInjector = new IEnumerableExtensions.InjectorDelegate<ThreadEntry, ThreadEntryDetailsItemModel>(DetailItemInjector);

            // Create the details view model
            ThreadEntryDetailsModel threadEntryDetailsModel = new ThreadEntryDetailsModel();

            IQueryable<ThreadEntry> forumThreadEntries = _jCarrollOnlineV4DbContext.ForumThreadEntry.Include(forumThreadEntry => forumThreadEntry.Author)
                .Include(forumThreadEntry => forumThreadEntry.Forum)
                .Where(forumThreadEntry => forumThreadEntry.Forum.Id == forumId);

            //threadEntryDetailsModel.ForumThreadEntryDetailItems.ForumThreadEntries = 
            //    await forumThreadEntries.AsHierarchy("Id", "ParentId", id, 10)
            //    .ProjectToViewAsync(detailItemInjector).ConfigureAwait(false);

            threadEntryDetailsModel.Forum.InjectFrom(_jCarrollOnlineV4DbContext.Forum.Find(forumId)); 

            threadEntryDetailsModel.ForumThreadEntryDetailItems.NumberOfReplies = _jCarrollOnlineV4DbContext.ForumThreadEntry.Where(b => b.RootId == id).Count();

            return View(threadEntryDetailsModel);
        }

        // GET: ForumOriginalPost/Create
        [Authorize]
        [HttpGet]
        public  ActionResult Create(int forumId, int? parentId, int? rootId)
        {
            ThreadEntriesCreateModel threadEntriesCreateViewModel = new ThreadEntriesCreateModel
            {
                ForumId = forumId,
                ParentId = parentId,
                RootId = rootId
            };

            return View(threadEntriesCreateViewModel);
        }

        // POST: ForumOriginalPost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create(/*[Bind(Include = "Title,RootId,ForumId,Content,ParentId,Id")]*/  ThreadEntriesCreateModel forumThreadEntryViewModel)
        {
            if (ModelState.IsValid)
            {
                ThreadEntry threadEntry = new ThreadEntry();

                threadEntry.InjectFrom(forumThreadEntryViewModel);

                threadEntry.CreatedAt = DateTime.Now;
                threadEntry.UpdatedAt = DateTime.Now;

                string? currentUserId = User?.Identity?.Name;
                ApplicationUser? currentUser = await _jCarrollOnlineV4DbContext.ApplicationUser.FirstOrDefaultAsync(x => x.Id == currentUserId).ConfigureAwait(false);

                threadEntry.Author = currentUser;
                if (forumThreadEntryViewModel != null)
                {
                    threadEntry.Forum = _jCarrollOnlineV4DbContext.Forum.Find(forumThreadEntryViewModel.ForumId);
                }
                threadEntry.PostNumber = threadEntry.ParentId != null
                    ? await _jCarrollOnlineV4DbContext.ForumThreadEntry.Where(m => m.RootId == threadEntry.RootId).CountAsync().ConfigureAwait(false) + 1
                    : 1;

                _jCarrollOnlineV4DbContext.ForumThreadEntry.Add(threadEntry);
                await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

                if (threadEntry.ParentId == null)
                {
                    threadEntry.UpdatedAt = threadEntry.CreatedAt;
                    threadEntry.RootId = threadEntry.Id;
                    await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);
                }

                return new RedirectResult(Url.Action("Details", new { forumId = threadEntry.Forum.Id, id = threadEntry.RootId }) + "#post" + threadEntry.PostNumber);
            }

            return View(forumThreadEntryViewModel);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult AdminCreate(int forumId, int? parentId, int? rootId)
        {
            AdminThreadEntriesCreateModel threadEntriesCreateModel = new AdminThreadEntriesCreateModel
            {
                ForumId = forumId,
                ParentId = parentId,
                RootId = rootId
            };

            return View(threadEntriesCreateModel);
        }

        // POST: ForumOriginalPost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        [Authorize(Roles = "Administrator")]
#pragma warning disable CA5363 // Do Not Disable Request Validation
        public async Task<ActionResult> AdminCreate(/*[Bind(Include = "Title,RootId,ForumId,Content,ParentId,Id")]*/ AdminThreadEntriesCreateModel forumThreadEntryModel)
#pragma warning restore CA5363 // Do Not Disable Request Validation
        {
            if (ModelState.IsValid)
            {
                ThreadEntry threadEntry = new ThreadEntry();

                threadEntry.InjectFrom(forumThreadEntryModel);

                threadEntry.CreatedAt = DateTime.Now;
                threadEntry.UpdatedAt = DateTime.Now;

                string? currentUserId = User?.Identity?.Name;
                ApplicationUser? currentUser = await _jCarrollOnlineV4DbContext.ApplicationUser.FirstOrDefaultAsync(x => x.Id == currentUserId).ConfigureAwait(false);

                threadEntry.Author = currentUser;
                if (forumThreadEntryModel != null)
                {
                    threadEntry.Forum = _jCarrollOnlineV4DbContext.Forum.Find(forumThreadEntryModel.ForumId);
                }
                threadEntry.PostNumber = threadEntry.ParentId != null
                    ? await _jCarrollOnlineV4DbContext.ForumThreadEntry.Where(m => m.RootId == threadEntry.RootId).CountAsync().ConfigureAwait(false) + 1
                    : 1;

                _jCarrollOnlineV4DbContext.ForumThreadEntry.Add(threadEntry);
                await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

                if (threadEntry.ParentId == null)
                {
                    threadEntry.UpdatedAt = threadEntry.CreatedAt;
                    threadEntry.RootId = threadEntry.Id;
                    await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);
                }

                return new RedirectResult(Url.Action("Details", new { forumId = threadEntry.Forum.Id, id = threadEntry.RootId }) + "#post" + threadEntry.PostNumber);
            }

            return View(forumThreadEntryModel);
        }

        // GET: ForumOriginalPost/Edit/5
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            ThreadEntriesEditModel threadEntriesModel = new ThreadEntriesEditModel();

            ThreadEntry? forumThread = await _jCarrollOnlineV4DbContext.ForumThreadEntry.Include("Forum").SingleOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);

            threadEntriesModel.InjectFrom(forumThread);
            threadEntriesModel.ForumId = forumThread.Forum.Id;
            threadEntriesModel.AuthorId = forumThread.Author.Id;

            return View(threadEntriesModel);
        }

        // POST: ForumOriginalPost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Edit(/*[Bind(Include = "Id,ParentId,RootId,ForumId,AuthorId,Title,Content,CreatedAt,Locked,PostNumber")]*/ ThreadEntriesEditModel forumThreadEntry)
        {
            if (ModelState.IsValid)
            {
                ThreadEntry threadEntry = new ThreadEntry();

                threadEntry.InjectFrom(forumThreadEntry);
                if (forumThreadEntry != null)
                {
                    threadEntry.Author = await _jCarrollOnlineV4DbContext.ApplicationUser.FindAsync(forumThreadEntry.AuthorId).ConfigureAwait(false);
                    threadEntry.Forum = await _jCarrollOnlineV4DbContext.Forum.FindAsync(forumThreadEntry.ForumId).ConfigureAwait(false);
                }
                threadEntry.UpdatedAt = DateTime.Now;

                _jCarrollOnlineV4DbContext.Entry(threadEntry).State = EntityState.Modified;
                await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

                return Redirect(Url.RouteUrl(new { controller = "ForumThreadEntries", action = "Details", forumId = threadEntry.Forum.Id, id = threadEntry.RootId }) + "#post" + threadEntry.PostNumber);
            }

            return View(forumThreadEntry);
        }

        // GET: ForumOriginalPost/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult> AdminEdit(int? id)
        {
            ThreadEntriesEditModel threadEntriesViewModel = new ThreadEntriesEditModel();

            ThreadEntry forumThread = await _jCarrollOnlineV4DbContext.ForumThreadEntry.Include("Forum").SingleOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);

            threadEntriesViewModel.InjectFrom(forumThread);
            threadEntriesViewModel.ForumId = forumThread.Forum.Id;
            threadEntriesViewModel.AuthorId = forumThread.Author.Id;

            return View(threadEntriesViewModel);
        }

        // POST: ForumOriginalPost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        [Authorize(Roles = "Administrator")]
#pragma warning disable CA5363 // Do Not Disable Request Validation
        public async Task<ActionResult> AdminEdit(/*[Bind(Include = "Id,ParentId,RootId,ForumId,AuthorId,Title,Content,CreatedAt,Locked,PostNumber")]*/ ThreadEntriesEditModel forumThreadEntry)
#pragma warning restore CA5363 // Do Not Disable Request Validation
        {
            if (ModelState.IsValid)
            {
                ThreadEntry threadEntry = new ThreadEntry();

                threadEntry.InjectFrom(forumThreadEntry);
                if (forumThreadEntry != null)
                {
                    threadEntry.Author = await _jCarrollOnlineV4DbContext.ApplicationUser.FindAsync(forumThreadEntry.AuthorId).ConfigureAwait(false);
                    threadEntry.Forum = await _jCarrollOnlineV4DbContext.Forum.FindAsync(forumThreadEntry.ForumId).ConfigureAwait(false);
                }
                threadEntry.UpdatedAt = DateTime.Now;

                _jCarrollOnlineV4DbContext.Entry(threadEntry).State = EntityState.Modified;
                await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

                return Redirect(Url.RouteUrl(new { controller = "ForumThreadEntries", action = "Details", forumId = threadEntry.Forum.Id, id = threadEntry.RootId }) + "#post" + threadEntry.PostNumber);
            }

            return View(forumThreadEntry);
        }

        // GET: ForumOriginalPost/Delete/5
        [Authorize]
        [HttpGet]
        public async Task<ThreadEntry> Delete(int? id)
        {
            ThreadEntry threadEntry = await _jCarrollOnlineV4DbContext.ForumThreadEntry.Include("Author").Include("Forum").Where(m => m.Id == id).SingleOrDefaultAsync().ConfigureAwait(false);
            ThreadEntryDetailsItemModel threadEntryDetailsItemViewModel = new ThreadEntryDetailsItemModel();

            threadEntryDetailsItemViewModel.InjectFrom(threadEntry);
            threadEntryDetailsItemViewModel.Author.InjectFrom(threadEntry.Author);
            threadEntryDetailsItemViewModel.Forum.InjectFrom(threadEntry.Forum);

            return threadEntry;// == null ? HttpNotFound() : (ActionResult)View(threadEntryDetailsItemViewModel);
        }

        // POST: ForumOriginalPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ThreadEntry? threadEntry = await _jCarrollOnlineV4DbContext.ForumThreadEntry.Include("Author").Include("Forum").Where(m => m.Id == id).SingleOrDefaultAsync().ConfigureAwait(false);
            string? userId = User?.Identity?.Name;
            ApplicationUser? user = await _jCarrollOnlineV4DbContext.ApplicationUser.FindAsync(userId).ConfigureAwait(false);

            threadEntry.Title = "This post was deleted on " + DateTime.Now + " by " + user?.UserName;
            threadEntry.Content = "";
            threadEntry.Locked = true;
            threadEntry.UpdatedAt = DateTime.Now;
            _jCarrollOnlineV4DbContext.Entry(threadEntry).State = EntityState.Modified;

            await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

            return threadEntry.ParentId == null
                ? RedirectToAction("Index", new { forumId = threadEntry.Forum.Id })
                : (ActionResult)Redirect(Url.RouteUrl(new { controller = "ForumThreadEntries", action = "Details", forumId = threadEntry.Forum.Id, id = threadEntry.RootId }) + "#post" + threadEntry.PostNumber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }

            base.Dispose(disposing);
        }
    }
}
