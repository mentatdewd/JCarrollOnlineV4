using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IForumThreadEntryRepository
    {
        ForumThreadEntry GetThread(int forumId);

        ForumThreadEntry GetThreadEntry(int threadEntryId);

        void CreateThread(ForumThreadEntry thread);

        void ReplyThread(ForumThreadEntry replyThread);
        void DeleteThread(int threadId);
        void DeleteThreadEntry(int threadEntryId);
        void UpdateThreadEntry(ForumThreadEntry thread);
    }
}
