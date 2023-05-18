namespace jcarrollonlinev4.backend.Models.ForumModerators
{
    public class ForumModeratorsCreateModel : ForumModeratorsModelBase
    {
        public int ForumId { get; set; }
        public DateTime CreatedAt { get; set; }//  :null => false
        public DateTime UpdatedAt { get; set; }//   :null => false
    }
}
