using jcarrollonlinev4.backend.Models.Users;

namespace jcarrollonlinev4.backend.Models.ForumThreadEntries
{
    public class ForumThreadsGetModel
    {
        public string? Title { get; set; }

        public string? Content { get; set; }

        public bool Locked { get; set; }

        public DateTime CreatedAt { get; set; } //           :null => false

        public DateTime UpdatedAt { get; set; } //          :null => false

        public int PostNumber { get; set; }

        public int? ParentId { get; set; }

        public int? RootId { get; set; }

        public ApplicationUserModel? Author { get; set; }
    }
}
