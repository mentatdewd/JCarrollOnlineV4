using jcarrollonlinev4.backend.Models.Blog;
using jcarrollonlinev4.backend.Models.Micropost;
using jcarrollonlinev4.backend.Models.Rss;
using jcarrollonlinev4.backend.Models.Users;

namespace jcarrollonlinev4.backend.Models.Home
{
    public class HomeModel : ModelBase
    {
        public MicropostCreateModel? MicropostCreateModel { get; set; }
        public MicropostFeedModel? MicropostFeedModel { get; set; }
        public UserStatsModel? UserStatsModel { get; set; }
        public UserItemModel? UserInfoModel { get; set; }
        public RssFeedModel? RssFeedModel { get; set; }
        public int MicroPosts { get; set; }
        public BlogFeedModel? BlogFeed { get; set; }
        public LatestForumThreadsModel? LatestForumThreadsModel { get; set; }

        public int? MicroPostPage { get; set; }
 //       public List<MicroPostFeedItemViewModel> OnePageOfMicroPosts { get; private set; }
        public int? PageNumber { get; set; }
    }
}
