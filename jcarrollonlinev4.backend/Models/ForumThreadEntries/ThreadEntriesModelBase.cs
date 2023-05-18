using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.ForumThreadEntries
{
    public class ThreadEntriesModelBase : ModelBase
    {
        [Required]
        public int Id { get; set; }

    }
}
