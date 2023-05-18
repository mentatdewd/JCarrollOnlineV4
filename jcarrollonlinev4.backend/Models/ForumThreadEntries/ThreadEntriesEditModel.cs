using jcarrollonlinev4.backend.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.ForumThreadEntries
{
    public class ThreadEntriesEditModel : ThreadEntriesModelBase
    {
        public int? ParentId { get; set; }
        public int? RootId { get; set; }
        public int ForumId { get; set; }
        public string? AuthorId { get; set; }

        [Display(Name = "Post Number")]
        public int PostNumber { get; set; }

        [Display(Name = "Locked")]
        public bool Locked { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Author")]
        public ApplicationUserModel? Author { get; set; }

        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string? Content { get; set; }
    }
}
