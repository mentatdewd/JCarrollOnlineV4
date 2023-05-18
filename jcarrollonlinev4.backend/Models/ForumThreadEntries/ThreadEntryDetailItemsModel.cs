using jcarrollonlinev4.backend.Models.HierarchyNode;

namespace jcarrollonlinev4.backend.Models.ForumThreadEntries
{
    public class ThreadEntryDetailItemsModel : ThreadEntriesModelBase
    {
        public int NumberOfReplies { get; set; }

        public IEnumerable<HierarchyNodesModel<ThreadEntryDetailsItemModel>>? ForumThreadEntries { get; set; }
    }
}
