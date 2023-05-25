using jcarrollonlinev4.backend.Models.ForumModerators;
using jcarrollonlinev4.backend.Models.ForumThreadEntries;
using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Fora
{
    public class ForaModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } // :null => false

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; } //:null => false

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public ICollection<ThreadEntryModel>? ForumThreadEntries { get; private set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public ICollection<ForumModeratorsModel>? ForumModerators { get; private set; }
    }
}
