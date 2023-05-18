namespace jcarrollonlinev4.backend.Models.Account
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login")]
    public class ExternalLoginListModel : ModelBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        public string? ReturnUrl { get; set; }
    }

}
