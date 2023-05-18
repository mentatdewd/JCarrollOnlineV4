using jcarrollonlinev4.backend.Entities;

namespace jcarrollonlinev4.backend.Models
{
    public class MicropostNotificationEmailModel : EmailModelBase
    {
        public ApplicationUser? MicropostAuthor { get; set; }
        public string? MicropostContent { get; set; }
    }
}
