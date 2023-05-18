using Microsoft.AspNetCore.Identity;

namespace jcarrollonlinev4.backend.Models.Manage
{
    public class ManageLoginsModel : ModelBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserLoginInfo>? CurrentLogins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public ICollection<AuthenticationDescription> OtherLogins { get; set; }
        public string? StatusMessage { get; set; }
        public bool ShowRemoveButton { get; set; }
    }
}
