using System;

namespace JCarrollOnline.ViewModels
{
    public class ForumThreadsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Replies { get; set; }

        public DateTime CreatedAt { get; set; } //           :null => false

        public DateTime LastReply { get; set; }
        
        public int Recs { get; set; }
 
        public int Views { get; set; }

        public bool Locked { get; set; }

        public string Author { get; set; } = string.Empty;
    }
}
