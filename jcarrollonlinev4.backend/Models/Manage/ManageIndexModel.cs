using Microsoft.AspNetCore.Identity;

namespace jcarrollonlinev4.backend.Models.Manage
{
    public class ManageIndexModel : ModelBase
    {
        public bool HasPassword { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserLoginInfo>? Logins { get; set; }
        public string? PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
        public string? StatusMessage { get; set; }
    }
}
