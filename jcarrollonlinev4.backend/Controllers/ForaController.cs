using jcarrollonlinev4.backend.Entities;
using jcarrollonlinev4.backend.Models.Fora;
using jcarrollonlinev4.backend.Models.ForumThreadEntries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;
using System.Reflection;

namespace jcarrollonlinev4.backend.Controllers.Fora
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForaController : ControllerBase
    {
        private readonly JCarrollOnlineV4DbContext _database;

        public ForaController(JCarrollOnlineV4DbContext dataContext)
        {
            _database = dataContext;
        }

        [HttpPost("CreateForum")]
        public async Task<ActionResult<ForaPostModel>> CreateForum([FromBody] ForaPostModel forumCreateModel)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Forum> forumEntry;

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(forumCreateModel.Title) || string.IsNullOrEmpty(forumCreateModel.Description))
                {
                    return BadRequest(ModelState);
                }

                bool result = _database.Forum.Any(a => a.Title == forumCreateModel.Title);
                if (result)
                {
                    return BadRequest(ModelState);
                }

                Forum forum = new Forum();

                forum.InjectFrom(forumCreateModel);
                forum.CreatedAt = DateTime.Now;
                forum.UpdatedAt = DateTime.Now;
                forumEntry = _database.Forum.Add(forum);
                await _database.SaveChangesAsync().ConfigureAwait(false);
                if (forumEntry != null)
                {
                    return CreatedAtAction(nameof(CreateForum), new { id = forumEntry.Entity.Id }, forumCreateModel);
                }
                return BadRequest();
            }
            else { return BadRequest(); }
        }

        [HttpGet("GetFora")]
        public ActionResult<List<ForaGetModel>> GetFora()
        {
            if (ModelState.IsValid)
            {
                List<ForaGetModel> fora = new List<ForaGetModel>();

                foreach (Forum forum in _database.Forum)
                {
                    ForaGetModel foraModel = new ForaGetModel();

                    foraModel.InjectFrom(forum);
                    fora.Add(foraModel);
                }

                return fora;
            }
            else { return BadRequest(); }
        }

        [HttpPost("DeleteForum")]
        public async Task<ActionResult<ForaGetModel>> DeleteForum(int id)
        {
            if (ModelState.IsValid)
            {
                Forum? forum = await _database.Forum.SingleOrDefaultAsync(x => x.Id == id);

                if (forum != null)
                {
                    _database.Forum.Remove(forum);
                    await _database.SaveChangesAsync().ConfigureAwait(false);

                    ForaGetModel model = new ForaGetModel();
                    model.InjectFrom(forum);
                    return model;
                }
            }
            return BadRequest();
        }

        [HttpGet("GetForumThreads")]
        public ActionResult<List<ForumThreadsGetModel>> GetForumThreads(int forumId)
        {
            if (ModelState.IsValid)
            {
                List<ForumThreadsGetModel> forumThreadEntries = new List<ForumThreadsGetModel>();

                foreach (ForumThreadEntry forumThreadEntry in _database.ForumThreadEntry.Where(te => te.Forum.Id == forumId))
                {
                    ForumThreadsGetModel forumThreadEntryModel = new ForumThreadsGetModel();

                    forumThreadEntryModel.InjectFrom(forumThreadEntry);
                    forumThreadEntries.Add(forumThreadEntryModel);
                }

                return forumThreadEntries;
            }
            return BadRequest();
        }

        [HttpPost("CreateForumThreadEntry")]
        public async Task<ActionResult<ForumThreadEntryPostModel>> CreateForumThreadEntry([FromBody] ForumThreadEntryPostModel forumThreadEntryPostModel)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Forum> forumEntry;

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(forumThreadEntryPostModel.Title) || string.IsNullOrEmpty(forumThreadEntryPostModel.Content))
                {
                    return BadRequest(ModelState);
                }

                bool result = _database.Forum.Any(a => a.Title == forumThreadEntryPostModel.Title);
                if (result)
                {
                    return BadRequest(ModelState);
                }

                Forum forum = new Forum();

                forum.InjectFrom(forumThreadEntryPostModel);
                forum.CreatedAt = DateTime.Now;
                forum.UpdatedAt = DateTime.Now;
                forumEntry = _database.Forum.Add(forum);
                await _database.SaveChangesAsync().ConfigureAwait(false);
                if (forumEntry != null)
                {
                    return CreatedAtAction(nameof(CreateForum), new { id = forumEntry.Entity.Id }, forumThreadEntryPostModel);
                }
                return BadRequest();
            }
            else { return BadRequest(); }
        }
    }
}
