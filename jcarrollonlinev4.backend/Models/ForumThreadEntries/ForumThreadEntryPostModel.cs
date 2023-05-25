namespace jcarrollonlinev4.backend.Models.ForumThreadEntries
{
    public class ForumThreadEntryPostModel
    {
        public string Title { get; set; } = "";

        public string Content { get; set; } = "";

        public DateTime CreatedAt { get; set; } //           :null => false

        public DateTime UpdatedAt { get; set; } //          :null => false
    }
    
}
