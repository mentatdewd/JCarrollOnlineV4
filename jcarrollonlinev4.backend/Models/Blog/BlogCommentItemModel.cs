using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Blog
{
    public class BlogCommentItemModel : BlogFeedModelBase
    {
        public BlogCommentItemModel() { }
        public BlogCommentItemModel(int blogItemId)
        {
            BlogItemId = blogItemId;
        }

        public int Id { get; set; }

        [RegularExpression("^[a-z0-9_-]{3,16}$", ErrorMessage = "User name must contain only lower case a-z, numbers, underscore,or hyphen and be at least 3 characters")]
        [Required]
        [StringLength(16)]
        public string? Author { get; set; }

        [Required]
        [StringLength(512)]
        public string? Content { get; set; }

        public int BlogItemId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? TimeAgo { get; set; }

        public Uri? ReturnUrl { get; set; }
    }
}
