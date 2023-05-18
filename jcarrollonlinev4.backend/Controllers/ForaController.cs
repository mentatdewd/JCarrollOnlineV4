using jcarrollonlinev4.backend.Entities;
using jcarrollonlinev4.backend.Models.Fora;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;
using System.Net;

namespace JCarrollOnlineV2.Controllers
{
    public class ForaController : Controller
    {
        private JCarrollOnlineV4DbContext _jCarrollOnlineV4DbContext { get; set; }

        public ForaController(JCarrollOnlineV4DbContext dataContext)
        {
            _jCarrollOnlineV4DbContext = dataContext;
        }

        // GET: Fora
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            ForaIndexModel foraIndexViewModel = new ForaIndexModel
            {
                ForaIndexItems = new List<ForaIndexItemModel>()
            };

            List<Forum> fora = await _jCarrollOnlineV4DbContext.Forum.ToListAsync().ConfigureAwait(false);

            foreach(Forum forum in fora)
            {
                ForaIndexItemModel foraIndexItemViewModel = new ForaIndexItemModel();

                foraIndexItemViewModel.InjectFrom(forum);
                //foraIndexItemViewModel.ThreadCount = await ControllerHelpers.GetThreadCountAsync(forum, Data).ConfigureAwait(false);

                if (foraIndexItemViewModel.ThreadCount > 0)
                {
                    //foraIndexItemViewModel.LastThread = await ControllerHelpers.GetLatestThreadDataAsync(forum, Data).ConfigureAwait(false);
                }

                foraIndexViewModel.ForaIndexItems.Add(foraIndexItemViewModel);
            }

            return View(foraIndexViewModel);
        }

        // GET: Fora/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            Forum forum = await _jCarrollOnlineV4DbContext.Forum.FindAsync(id).ConfigureAwait(false);

            return /*forum == null ? HttpNotFound() :*/ (ActionResult)View(forum);
        }

        // GET: Fora/Create
        //[Authorize(Roles ="Administrator")]
        [HttpGet]
        public ActionResult Create()
        {
            ForaCreateModel foraCreateViewModel = new ForaCreateModel();

            return View(foraCreateViewModel);
        }

        // POST: Fora/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize]
        public async Task<ActionResult> Create(/*[Bind(Include = "Title,Description,CreatedAt,UpdatedAt")]*/ ForaCreateModel forumViewModel)
        {
            if (ModelState.IsValid)
            {
                Forum forum = new Forum();

                forum.InjectFrom(forumViewModel);
                forum.CreatedAt = DateTime.Now;
                forum.UpdatedAt = DateTime.Now;
                _jCarrollOnlineV4DbContext.Forum.Add(forum);
                await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

                return RedirectToAction("Index");
            }

            return View(forumViewModel);
        }

        // GET: Fora/Edit/5
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            Forum? forum = await _jCarrollOnlineV4DbContext.Forum.FindAsync(id).ConfigureAwait(false);
            ForumEditModel forumEditViewModel = new ForumEditModel();

            forumEditViewModel.InjectFrom(forum);

            return /*forum == null ? HttpNotFound() : */(ActionResult)View(forumEditViewModel);
        }

        // POST: Fora/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize]
        public async Task<ActionResult> Edit(/*[Bind(Include = "Id,Title,Description,CreatedAt,UpdatedAt")]*/ Forum forum)
        {
            if (ModelState.IsValid)
            {
                _jCarrollOnlineV4DbContext.Entry(forum).State = EntityState.Modified;
                await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

                return RedirectToAction("Index");
            }

            return View(forum);
        }

        // GET: Fora/Delete/5
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            Forum? forum = await _jCarrollOnlineV4DbContext.Forum.FindAsync(id).ConfigureAwait(false);
            ForumDeleteModel forumDeleteViewModel = new ForumDeleteModel();

            forumDeleteViewModel.InjectFrom(forum);

            return /*forum == null ? HttpNotFound() : */(ActionResult)View(forumDeleteViewModel);
        }

        // POST: Fora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Forum? forum = await _jCarrollOnlineV4DbContext.Forum.FindAsync(id).ConfigureAwait(false);

            _jCarrollOnlineV4DbContext.Forum.Remove(forum);
            await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

            return RedirectToAction("Index");
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
