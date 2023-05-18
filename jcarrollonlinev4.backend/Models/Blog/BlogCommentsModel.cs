namespace jcarrollonlinev4.backend.Models.Blog
{
    public class BlogCommentsModel : BlogFeedModelBase
    {
        public BlogCommentsModel()
        {
            BlogComments = new List<BlogCommentItemModel>();
        }
        public int BlogItemId { get; set; }
        public ICollection<BlogCommentItemModel> BlogComments { get; private set; }
    }
}
