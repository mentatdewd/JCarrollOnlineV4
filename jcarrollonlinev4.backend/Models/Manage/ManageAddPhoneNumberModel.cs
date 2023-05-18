using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Manage
{
    public class ManageAddPhoneNumberModel : ModelBase
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string? Number { get; set; }
    }
}
