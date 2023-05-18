using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Account
{
    public class VerifyCodeModel : ModelBase
    {
        [Required]
        public string? Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string? Code { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        public string? ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }
}
