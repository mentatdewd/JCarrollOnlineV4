using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Rss
{
    public class RssFeedItemModel : RssFeedModelBase
    {
        [DataType(DataType.Url)]
        public Uri? Link { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }

        public string? Title { get; set; }
    }
}
