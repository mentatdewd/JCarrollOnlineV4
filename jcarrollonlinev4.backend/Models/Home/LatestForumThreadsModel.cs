using System.Collections.ObjectModel;

namespace jcarrollonlinev4.backend.Models.Home
{
    public class LatestForumThreadsModel : ModelBase
    {
        public Collection<LatestForumThreadItemModel> LatestForumThreads { get; private set; } = new Collection<LatestForumThreadItemModel>();
    }
}
