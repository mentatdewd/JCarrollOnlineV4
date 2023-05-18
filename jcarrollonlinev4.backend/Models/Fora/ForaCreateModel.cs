using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Fora
{
    public class ForaCreateModel : ForaModelBase
    {
        [Required]
        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
