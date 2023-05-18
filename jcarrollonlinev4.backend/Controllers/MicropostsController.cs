using jcarrollonlinev4.backend.Entities;
using jcarrollonlinev4.backend.Models;
using jcarrollonlinev4.backend.Models.Micropost;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;
using System.Net;

namespace JCarrollOnlineV2.Controllers
{
    [Authorize]
    public class MicroPostsController : Controller
    {
        private JCarrollOnlineV4DbContext _jCarrollOnlineV4DbContext { get; set; }

        public MicroPostsController(JCarrollOnlineV4DbContext dataContext)
        {
            _jCarrollOnlineV4DbContext = dataContext;
        }

        // GET: MicroPosts
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _jCarrollOnlineV4DbContext.Micropost.ToListAsync().ConfigureAwait(false));
        }

        // GET: MicroPosts/Details/5
        //[HttpGet]
        //public async MicropostIndexModel Details(int? id)
        //{
        //    Micropost? microPost = await _data.Micropost.FindAsync(id).ConfigureAwait(false);

        //    return /*microPost == null ? HttpNotFound() :*/ (ActionResult)View(microPost);
        //}

        // GET: MicroPosts/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MicroPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(/*[Bind(Include = "Id,Content,UserId,CreatedAt,UpdatedAt")]*/ MicropostCreateModel micropostCreateModel)
        {
            if (ModelState.IsValid)
            {
                Micropost micropost = new Micropost();

                micropost.InjectFrom(micropostCreateModel);
                micropost.CreatedAt = DateTime.Now;
                micropost.UpdatedAt = DateTime.Now;

                string? currentUserId = User?.Identity?.Name;
                ApplicationUser? currentUser = await _jCarrollOnlineV4DbContext.ApplicationUser.Include("Followers").FirstOrDefaultAsync(x => x.Id == currentUserId).ConfigureAwait(false);

                micropost.Author = currentUser;
                _jCarrollOnlineV4DbContext.Micropost.Add(micropost);
                await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

                await SendMicropostNotification(micropost, currentUser).ConfigureAwait(false);

                return RedirectToAction("Index", "Home");
            }

            return View(micropostCreateModel);
        }

        private async Task SendMicropostNotification(Micropost micropost, ApplicationUser currentUser)
        {
            foreach (ApplicationUser user in currentUser.Followers)
            {
                if (user.MicroPostEmailNotifications == true)
                {
                    MicropostNotificationEmailModel micropostNotificationEmailModel = GenerateViewModel(micropost, currentUser, user);
                    
                    await SendEmail(micropostNotificationEmailModel).ConfigureAwait(false);
                }
            }

            if (currentUser.MicroPostEmailNotifications == true)
            {
                MicropostNotificationEmailModel microPostNotificationEmailModel = GenerateViewModel(micropost, currentUser, currentUser);

                await SendEmail(microPostNotificationEmailModel).ConfigureAwait(false);
            }
        }

        private static MicropostNotificationEmailModel GenerateViewModel(Micropost micropost, ApplicationUser currentUser, ApplicationUser user)
        {
            MicropostNotificationEmailModel micropostNotificationEmailModel = new MicropostNotificationEmailModel
            {
                TargetUser = user,
                MicropostAuthor = currentUser,
                MicropostContent = micropost.Content
            };

            return micropostNotificationEmailModel;
        }

        private async Task SendEmail(MicropostNotificationEmailModel microPostNotificationEmailViewModel)
        {

            string templateFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmailTemplates");
            string templateFilePath = System.IO.Path.Combine(templateFolderPath, "MicroPostNotificationPage.cshtml");
            // TODO: Convert to using RazorLight...
            //using (IRazorEngineService templateService = RazorEngineService.Create())
            //{
            //    microPostNotificationEmailViewModel.Content = templateService.RunCompile(System.IO.File.ReadAllText(templateFilePath), "microPostTemplatekey", null, microPostNotificationEmailViewModel);
            //    await SendEmailAsync(microPostNotificationEmailViewModel).ConfigureAwait(false);
            //}
        }

        public async Task SendEmailAsync(MicropostNotificationEmailModel microPostNotificationEmailViewModel)
        {
            if (microPostNotificationEmailViewModel != null)
            {
                //IdentityMessage email = new IdentityMessage()
                //{
                //    Body = microPostNotificationEmailViewModel.Content,
                //    Destination = microPostNotificationEmailViewModel.TargetUser.UserName + " " + microPostNotificationEmailViewModel.TargetUser.Email,
                //    Subject = microPostNotificationEmailViewModel.MicroPostAuthor.UserName + " has added a new micropost"
                //};

                //await UserManager.EmailService.SendAsync(email).ConfigureAwait(false);
            }
        }

        // GET: MicroPosts/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? microPostId)
        {
            Micropost? micropost = await _jCarrollOnlineV4DbContext.Micropost.FindAsync(microPostId).ConfigureAwait(false);

            return /*micropost == null ? HttpNotFound() :*/ (ActionResult)View(micropost);
        }

        // POST: MicroPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(/*[Bind(Include = "Id,Content,UserId,CreatedAt,UpdatedAt")]*/ Micropost micropost)
        {
            if (ModelState.IsValid)
            {
                _jCarrollOnlineV4DbContext.Entry(micropost).State = EntityState.Modified;
                await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);

                return RedirectToAction("Index");
            }

            return View(micropost);
        }

        // GET: MicroPosts/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int? micropostId)
        {
            Micropost? micropost = await _jCarrollOnlineV4DbContext.Micropost.FindAsync(micropostId).ConfigureAwait(false);

            return /*micropost == null ? HttpNotFound() : */(ActionResult)View(micropost);
        }

        // POST: MicroPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int micropostId)
        {
            Micropost? micropost = await _jCarrollOnlineV4DbContext.Micropost.FindAsync(micropostId).ConfigureAwait(false);

            _jCarrollOnlineV4DbContext.Micropost.Remove(micropost);
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
