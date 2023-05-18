namespace jcarrollonlinev4.backend.Models.Account
{
    public class SendCodeModel : ModelBase
    {
        public string? SelectedProvider { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        public string? ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
