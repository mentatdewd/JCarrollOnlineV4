namespace jcarrollonlinev4.backend.Models.Blog
{
    public class BlogCommentModel
    {
        public string? Author { get; set; }
        public string? Content { get; set; }
        public int BlogItemId { get; set; }
    }
}
