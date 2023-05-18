namespace jcarrollonlinev4.backend.Models.Blog
{
    public class BlogIndexModel : BlogFeedModelBase
    {
        public BlogIndexModel()
        {
            BlogFeedItems = new BlogFeedModel();
        }

        public BlogFeedModel BlogFeedItems { get; set; }
    }
}
