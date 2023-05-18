using jcarrollonlinev4.backend.Models.Fora;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace jcarrollonlinev4.backend.Models.ForumThreadEntries
{
    public class ThreadEntryIndexModel : ThreadEntriesModelBase
    {
        private ICollection<ThreadEntryIndexItemModel> _threadEntryIndex = new List<ThreadEntryIndexItemModel>();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ThreadEntryIndexItemModel> ThreadEntryIndex => _threadEntryIndex;

        public ForaModel Forum { get; set; }

        [DataType(DataType.Text)]
        [StringLength(256)]
        [Display(Name = "Title")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string? Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Content { get; set; }
    }
}
