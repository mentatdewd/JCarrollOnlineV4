using jcarrollonlinev4.backend.Models.Micropost;
using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Users
{
    public class UserItemModel : UserModelBase
    {
        public UserItemModel() { }
        public string? UserId { get; set; }

        [Display(Name = "Micropost Email Notifications")]
        public bool MicropostEmailNotifications { get; set; }

        [Display(Name = "Micropost SMS Notifications")]
        public bool MicropostSmsNotifications { get; set; }

        public int? MicropostsAuthored { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<MicropostFeedItemModel>? Microposts { get; set; }
        //public Logger Logger { get; set; }
    }
}
