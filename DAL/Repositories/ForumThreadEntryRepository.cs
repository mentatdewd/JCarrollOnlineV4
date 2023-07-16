using DAL.Models;
using DAL.Repositories.Interfaces;
using System;

namespace DAL.Repositories
{
    internal class ForumThreadEntryRepository : Repository<Forum>, IForumThreadEntryRepository
    {
        public ForumThreadEntryRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            AppDbContext = appDbContext;
        }


        public void CreateThread(ForumThreadEntry thread)
        {
            throw new NotImplementedException();
        }

        public void DeleteThread(int threadId)
        {
            throw new NotImplementedException();
        }

        public void DeleteThreadEntry(int threadEntryId)
        {
            throw new NotImplementedException();
        }

        public ForumThreadEntry GetThread(int forumId)
        {
            throw new NotImplementedException();
        }

        public ForumThreadEntry GetThreadEntry(int threadEntryId)
        {
            throw new NotImplementedException();
        }

        public void ReplyThread(ForumThreadEntry replyThread)
        {
            throw new NotImplementedException();
        }

        public void UpdateThreadEntry(ForumThreadEntry thread)
        {
            throw new NotImplementedException();
        }
        private ApplicationDbContext _appDbContext;
        public ApplicationDbContext AppDbContext
        {
            get => _appDbContext;
            init => _appDbContext = value;
        }
    }
}
