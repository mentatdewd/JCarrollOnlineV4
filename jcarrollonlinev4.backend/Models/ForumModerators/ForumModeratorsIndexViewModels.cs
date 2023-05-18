using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.ForumModerators
{
    public class ForumModeratorsIndexModel : ForumModeratorsModelBase
    {
        [Display(Name="Forum Id")]
        public int ForumId { get; set; }

        [Display(Name="Created At")]
        public DateTime CreatedAt { get; set; }//  :null => false

        [Display(Name="Updated At")]
        public DateTime UpdatedAt { get; set; }//   :null => false
    }
}
