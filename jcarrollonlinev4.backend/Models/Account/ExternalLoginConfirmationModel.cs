﻿using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Account
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login")]
    public class ExternalLoginConfirmationModel : ModelBase
    {
        [Required]
        public string? SiteUserName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        public string? ReturnUrl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login")]
        public string? LoginProvider { get; set; }
    }
}
