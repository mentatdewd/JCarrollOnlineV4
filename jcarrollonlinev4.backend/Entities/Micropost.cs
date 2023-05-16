using System.ComponentModel.DataAnnotations;

namespace webapi.Entities
{
    public class Micropost
    {
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(140)]
        public string? Content { get; set; }

        [Required]
        public ApplicationUser? Author { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatedAt { get; set; } // :null => false

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime UpdatedAt { get; set; } // :null => false
    }
}
