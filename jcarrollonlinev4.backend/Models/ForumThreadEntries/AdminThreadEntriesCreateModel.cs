using jcarrollonlinev4.backend.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.ForumThreadEntries
{
    public class AdminThreadEntriesCreateModel : ThreadEntriesModelBase
    {
        public int ParentPostNumber { get; set; }
        public int? ParentId { get; set; }
        public int? RootId { get; set; }
        public int ForumId { get; set; }

        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string? Content { get; set; }

        public ApplicationUserModel? Author { get; set; }
    }
}
