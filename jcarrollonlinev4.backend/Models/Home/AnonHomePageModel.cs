using jcarrollonlinev4.backend.Models.Blog;

namespace jcarrollonlinev4.backend.Models.Home
{
    public class AnonHomepageModelBase : ModelBase
    {

    }

    public class AnonHomepageModel : AnonHomepageModelBase
    {
        public BlogFeedModel? BlogFeed { get; set; }
    }
}
