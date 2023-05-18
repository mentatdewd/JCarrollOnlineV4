namespace jcarrollonlinev4.backend.Models.Home
{
    public class LatestForumThreadItemModel : ModelBase
    {
        public string? ForumTitle { get; set; }
        public string? ThreadTitle { get; set; }

        public int ForumId { get; set; }

        public int ThreadId { get; set; }
    }
}
