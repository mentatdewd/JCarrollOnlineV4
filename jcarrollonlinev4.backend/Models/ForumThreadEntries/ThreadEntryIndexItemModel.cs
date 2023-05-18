using jcarrollonlinev4.backend.Models.Fora;
using jcarrollonlinev4.backend.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.ForumThreadEntries
{
    public class ThreadEntryIndexItemModel : ThreadEntriesModelBase
    {
        private ApplicationUserModel _author = new ApplicationUserModel();
        private ForaModel _forum = new ForaModel();

        public ForaModel Forum => _forum;

        [Display(Name = "Replies")]
        public int Replies { get; set; }

        [Display(Name = "Last Reply")]
        public DateTime LastReply { get; set; }

        [Display(Name = "Recs")]
        public int Recs { get; set; }

        [Display(Name = "Views")]
        public int Views { get; set; }

        [Display(Name = "Author")]
        public ApplicationUserModel Author => _author;

        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedAt { get; set; }
    }
}
