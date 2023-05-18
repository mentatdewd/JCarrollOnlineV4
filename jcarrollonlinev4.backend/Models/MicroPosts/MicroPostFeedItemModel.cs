using jcarrollonlinev4.backend.Models.Users;

namespace jcarrollonlinev4.backend.Models.Micropost
{
    public class MicropostFeedItemModel : MicropostModelBase
    {
        public MicropostFeedItemModel()
        {
            Author = new ApplicationUserModel();
        }
        public ApplicationUserModel? Author { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? TimeAgo { get; set; }
    }
}
