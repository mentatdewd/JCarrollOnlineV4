namespace jcarrollonlinev4.backend.Models.Fora
{
    public class ForaIndexModel : ForaModelBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ForaIndexItemModel>? ForaIndexItems { get; set; }
    }
}
