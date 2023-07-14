using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ForumThreadEntry
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.MultilineText)]
        public string Content { get; set; } = string.Empty;

        public bool Locked { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int PostNumber { get; set; }

        public int ParentId { get; set; }

        public int RootId { get; set; }

        [Required]
        [ForeignKey("Author_Id")]
        public virtual ApplicationUser Author { get; set; } = null!;

        [Required]
        [ForeignKey("Forum_Id")]
        public virtual Forum Forum { get; set; } = null!;

        [ForeignKey("Parent_Id")]
        public virtual Collection<ForumThreadEntry> Children { get; set; }
        public virtual ForumThreadEntry Parent { get; set; } = null!;
    }
}
