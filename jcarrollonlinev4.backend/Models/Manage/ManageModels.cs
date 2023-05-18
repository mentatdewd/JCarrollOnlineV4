namespace jcarrollonlinev4.backend.Models.Manage
{
    public class ManageConfigureTwoFactorModel : ModelBase
    {
        public string? SelectedProvider { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}