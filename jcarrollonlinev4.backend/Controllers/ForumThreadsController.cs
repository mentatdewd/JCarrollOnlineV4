using jcarrollonlinev4.backend.Entities;
using jcarrollonlinev4.backend.Models.ForumThreadEntries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;

namespace jcarrollonlinev4.backend.Controllers.ForumThreads
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForumThreads : ControllerBase
    {
        private readonly JCarrollOnlineV4DbContext _database;

        public ForumThreads(JCarrollOnlineV4DbContext dataContext)
        {
            _database = dataContext;
        }

        [HttpPost("CreateForumThread")]
        public async Task<ActionResult<ForumThreadEntryPostModel>> CreateForumThread([FromBody] ForumThreadEntryPostModel forumThreadEntryCreateModel)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Forum> forumEntry;

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(forumThreadEntryCreateModel.Title) || string.IsNullOrEmpty(forumThreadEntryCreateModel.Content))
                {
                    return BadRequest(ModelState);
                }

                bool result = _database.Forum.Any(a => a.Title == forumThreadEntryCreateModel.Title);
                if (result)
                {
                    return BadRequest(ModelState);
                }

                Forum forum = new Forum();

                forum.InjectFrom(forumThreadEntryCreateModel);
                forum.CreatedAt = DateTime.Now;
                forum.UpdatedAt = DateTime.Now;
                forumEntry = _database.Forum.Add(forum);
                await _database.SaveChangesAsync().ConfigureAwait(false);
                if (forumEntry != null)
                {
                    return CreatedAtAction(nameof(CreateForumThread), new { id = forumEntry.Entity.Id }, forumThreadEntryCreateModel);
                }
                return BadRequest();
            }
            else { return BadRequest(); }
        }

        [HttpGet("GetForumThreads")]
        public ActionResult<List<ForumThreadsGetModel>> GetForumThreads()
        {
            if (ModelState.IsValid)
            {
                List<ForumThreadsGetModel> forumThreadEntries = new List<ForumThreadsGetModel>();

                return forumThreadEntries;
            }
            else { return BadRequest(); }
        }

        [HttpPost("DeleteForumThread")]
        public async Task<ActionResult<ForumThreadDeleteModel>> DeleteForumThread(int id)
        {
            if (ModelState.IsValid)
            {
                Forum? forum = await _database.Forum.SingleOrDefaultAsync(x => x.Id == id);

                if (forum != null)
                {
                    _database.Forum.Remove(forum);
                    await _database.SaveChangesAsync().ConfigureAwait(false);

                    ForumThreadDeleteModel model = new ForumThreadDeleteModel();
                    model.InjectFrom(forum);
                    return model;
                }
            }
            return BadRequest();
        }
    }
}
