namespace jcarrollonlinev4.backend.Models.Blog
{
    public class BlogFeedModel : BlogFeedModelBase
    {
        public BlogFeedModel()
        {
            BlogFeedItemModels = new List<BlogFeedItemModel>();
        }
        public ICollection<BlogFeedItemModel> BlogFeedItemModels { get; private set; }
    }
}
