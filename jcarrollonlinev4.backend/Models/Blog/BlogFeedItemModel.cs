using jcarrollonlinev4.backend.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Blog
{
    public class BlogFeedItemModel : BlogFeedModelBase
    {
        public BlogFeedItemModel()
        {
            Author = new ApplicationUserModel();
            Comments = new BlogCommentsModel();
        }

        public int Id { get; set; }
        public ApplicationUserModel Author { get; set; }

        public string? AuthorId { get; set; }

        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        //[AllowHtml]
        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BlogCommentsModel Comments { get; set; }
    }
}
