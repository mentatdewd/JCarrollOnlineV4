using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Manage
{
    public class ManageVerifyPhoneNumberModel : ModelBase
    {
        [Required]
        [Display(Name = "Code")]
        public string? Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        public string? Status { get; set; }
    }
}
