using System;

namespace JCarrollOnline.ViewModels
{
    // All fora views
    public class ForaViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = "empty title";

        public string Description { get; set; } = "empty description";

        public DateTime CreatedAt { get; set; } // :null => false

        public DateTime UpdatedAt { get; set; } //:null => false
    }
}
