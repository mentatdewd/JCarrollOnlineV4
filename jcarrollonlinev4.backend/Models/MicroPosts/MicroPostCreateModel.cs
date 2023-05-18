using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Micropost
{
    public class MicropostCreateModel : MicropostModelBase
    {
        [DataType(DataType.MultilineText)]
        [StringLength(140)]
        public string? Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } // :null => false

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; } // :null => false
    }
}
