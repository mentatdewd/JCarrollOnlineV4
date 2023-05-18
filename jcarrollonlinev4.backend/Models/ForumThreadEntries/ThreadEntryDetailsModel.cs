using jcarrollonlinev4.backend.Models.Fora;

namespace jcarrollonlinev4.backend.Models.ForumThreadEntries
{
    public class ThreadEntryDetailsModel : ThreadEntriesModelBase
    {
        private ThreadEntryDetailItemsModel _forumThreadEntryDetailItems = new ThreadEntryDetailItemsModel();
        private ForaDetailsModel _foraDetailsModel = new ForaDetailsModel();

        public ThreadEntryDetailItemsModel ForumThreadEntryDetailItems => _forumThreadEntryDetailItems;

        public ForaDetailsModel Forum => _foraDetailsModel;
        public int Replies { get; set; }
    }
}
