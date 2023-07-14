using System;
using System.Collections.ObjectModel;

namespace JCarrollOnline.ViewModels
{
    public class ForumThreadEntryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Locked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int PostNumber { get; set; }
        public int RootId { get; set; }
        public string Author { get; set; }
        public string AuthorEmail { get; set; }
        public int AuthorForumPostCount { get; set; }
        public int ForumId { get; set; }
        public int Replies { get; set; }
        public DateTime LastReply { get; set; }
        public int Recs { get; set; }
        public int Views { get; set; }
        public Collection<ForumThreadEntryViewModel> Children { get; set; }
        public int ParentId { get; set; }
    }
}
