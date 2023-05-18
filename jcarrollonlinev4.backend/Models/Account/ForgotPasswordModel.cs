using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Account
{
    public class ForgotPasswordModel : ModelBase 
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }
    }

}
