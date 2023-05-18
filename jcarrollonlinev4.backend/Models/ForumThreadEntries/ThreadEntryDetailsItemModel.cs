using jcarrollonlinev4.backend.Models.Fora;
using jcarrollonlinev4.backend.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace jcarrollonlinev4.backend.Models.ForumThreadEntries
{
    public class ThreadEntryDetailsItemModel : ThreadEntriesModelBase
    {
        public ThreadEntryDetailsItemModel()
        {
            Author = new ApplicationUserModel();
            Forum = new ForaModel();
        }

        public int? ParentId { get; set; }
        public int? RootId { get; set; }
        public int? ParentPostNumber { get; set; }
        public ForaModel Forum { get; set; }

        [Display(Name = "Parent Author")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string? ParentAuthor { get; set; }

        [Display(Name = "Post Count")]
        public int PostCount { get; set; }

        [Display(Name = "Author")]
        public ApplicationUserModel Author { get; set; }

        [Display(Name = "Content")]
        public string? Content { get; set; }

        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated On")]
        public DateTime UpdatedAt { get; set; }

        [Display(Name = "Post Number")]
        public int PostNumber { get; set; }

        public bool Locked { get; set; }
    }
}
