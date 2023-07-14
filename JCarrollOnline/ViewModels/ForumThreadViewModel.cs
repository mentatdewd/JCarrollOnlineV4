using DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JCarrollOnline.ViewModels
{
    public class ForumThreadViewModel
    {
        [Required]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [StringLength(256)]
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.MultilineText)]
        public string Content { get; set; } = string.Empty;

        public bool Locked { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } //           :null => false

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; } //          :null => false

        public int PostNumber { get; set; }

        public int ParentId { get; set; }

        public int RootId { get; set; }

        public string Author { get; set; }
        public int ForumId { get; set; }
    }
}

