using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.HierarchyNode
{
    public class HierarchyNodesModel<T> : ModelBase
    {
        [Required]
        public T? Entity { get; set; }

        [Required]
        public IEnumerable<HierarchyNodesModel<T>>? ChildNodes { get; set; }
        
        [Required]
        public int Depth { get; set; }
        
        [Required]
        public T? Parent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public List<string>? ImageList { get; set; }
    }
}
