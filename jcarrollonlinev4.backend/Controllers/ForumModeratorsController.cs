using jcarrollonlinev4.backend.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace JCarrollOnlineV2.Controllers
{
    //[Authorize(Roles="Administrator")]
    //public class ForumModeratorsController : Controller
    //{
    //    private JCarrollOnlineV4DbContext _jCarrollOnlineV4DbContext { get; set; }

    //    public ForumModeratorsController(JCarrollOnlineV4DbContext dataContext)
    //    {
    //        _jCarrollOnlineV4DbContext = dataContext;
    //    }

    //    // GET: ForumModerators
    //    [HttpGet]
    //    public async Task<ActionResult> Index()
    //    {
    //        return View(await _jCarrollOnlineV4DbContext.ForumModerator.ToListAsync().ConfigureAwait(false));
    //    }

    //    // GET: ForumModerators/Details/5
    //    [HttpGet]
    //    public async Task<ActionResult> Details(int? id)
    //    {
    //        ForumModerator? forumModerator = await _jCarrollOnlineV4DbContext.ForumModerator.FindAsync(id).ConfigureAwait(false);

    //        return /*forumModerator == null ? HttpNotFound() :*/ (ActionResult)View(forumModerator);
    //    }

    //    // GET: ForumModerators/Create
    //    [HttpGet]
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: ForumModerators/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> Create(/*[Bind(Include = "Id,Id,CreatedAt,UpdatedAt")]*/ ForumModerator forumModerator)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _jCarrollOnlineV4DbContext.ForumModerator.Add(forumModerator);
    //            await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

    //            return RedirectToAction("Index");
    //        }

    //        return View(forumModerator);
    //    }

    //    // GET: ForumModerators/Edit/5
    //    [HttpGet]
    //    public async Task<ActionResult> Edit(int? id)
    //    {
    //        ForumModerator forumModerator = await _jCarrollOnlineV4DbContext.ForumModerator.FindAsync(id).ConfigureAwait(false);

    //        return /*forumModerator == null ? HttpNotFound() : */(ActionResult)View(forumModerator);
    //    }

    //    // POST: ForumModerators/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> Edit(/*[Bind(Include = "Id,Id,CreatedAt,UpdatedAt")] */ForumModerator forumModerator)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _jCarrollOnlineV4DbContext.Entry(forumModerator).State = EntityState.Modified;
    //            await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

    //            return RedirectToAction("Index");
    //        }

    //        return View(forumModerator);
    //    }

    //    // GET: ForumModerators/Delete/5
    //    [HttpGet]
    //    public async Task<ActionResult> Delete(int? id)
    //    {
    //        ForumModerator? forumModerator = await _jCarrollOnlineV4DbContext.ForumModerator.FindAsync(id).ConfigureAwait(false);

    //        return /*forumModerator == null ? HttpNotFound() : */(ActionResult)View(forumModerator);
    //    }

    //    // POST: ForumModerators/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> DeleteConfirmed(int id)
    //    {
    //        ForumModerator? forumModerator = await _jCarrollOnlineV4DbContext.ForumModerator.FindAsync(id).ConfigureAwait(false);

    //        _jCarrollOnlineV4DbContext.ForumModerator.Remove(forumModerator);
    //        await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //        }

    //        base.Dispose(disposing);
    //    }
    //}
}
