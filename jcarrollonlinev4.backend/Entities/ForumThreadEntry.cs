﻿using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Entities
{
    public class ForumThreadEntry
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string? Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Content { get; set; }

        public bool Locked { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int PostNumber { get; set; }

        public int? ParentId { get; set; }

        public int? RootId { get; set; }

        [Required]
        public virtual ApplicationUser? Author { get; set; }

        [Required]
        public int ForumId { get; set; }

        [Required]
        public Forum Forum { get; set; } = null!;
    }
}
