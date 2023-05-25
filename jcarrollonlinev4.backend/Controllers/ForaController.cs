using jcarrollonlinev4.backend.Entities;
using jcarrollonlinev4.backend.Models.Fora;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace JCarrollOnlineV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForaController : ControllerBase
    {
        private JCarrollOnlineV4DbContext _jCarrollOnlineV4DbContext { get; set; }

        public ForaController(JCarrollOnlineV4DbContext dataContext)
        {
            _jCarrollOnlineV4DbContext = dataContext;
        }

        [HttpPost("CreateForum")]
        public async Task<ActionResult<ForaCreateModel>> CreateForum([FromBody] ForaCreateModel forumCreateModel)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Forum> forumEntry = null;

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(forumCreateModel.title) || string.IsNullOrEmpty(forumCreateModel.description))
                {
                    return BadRequest(ModelState);
                }

                bool result = _jCarrollOnlineV4DbContext.Forum.Any(a => a.Title == forumCreateModel.title);
                if (result)
                {
                    return BadRequest(ModelState);
                }

                Forum forum = new Forum();

                forum.InjectFrom(forumCreateModel);
                forum.CreatedAt = DateTime.Now;
                forum.UpdatedAt = DateTime.Now;
                forumEntry = _jCarrollOnlineV4DbContext.Forum.Add(forum);
                await _jCarrollOnlineV4DbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            if (forumEntry != null)
            {
                return CreatedAtAction(nameof(CreateForum), new { id = forumEntry.Entity.Id }, forumCreateModel);
            }
            else { return BadRequest(); }
        }

        [HttpGet("GetFora")]
        public ActionResult<List<ForaModel>> GetFora()
        {
            if (ModelState.IsValid)
            {
                List<ForaModel> fora = new List<ForaModel>();

                foreach (Forum forum in _jCarrollOnlineV4DbContext.Forum)
                {
                    ForaModel foraModel = new ForaModel();

                    foraModel.InjectFrom(forum);
                    fora.Add(foraModel);
                }

                return fora;
            }
            else { return BadRequest(); }
        }
    }
}
