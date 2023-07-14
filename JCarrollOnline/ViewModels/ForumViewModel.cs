using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JCarrollOnline.ViewModels
{
    // Forum detail query
    public class ForumViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } // :null => false

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; } //:null => false

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public ICollection<ForumThreadViewModel> ForumThreadEntries { get; private set; } = null!;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public ICollection<ForumModeratorsViewModel> ForumModerators { get; private set; } = null!;
    }
}
