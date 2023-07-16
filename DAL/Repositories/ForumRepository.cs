using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    internal class ForumRepository : Repository<Forum>, IForumRepository
    {
        public ForumRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public EntityEntry<Forum> CreateForum(Forum forum)
        {
            return _appDbContext.Fora.Add(forum);
        }

        public void DeleteForum(Forum forum)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAllFora()
        {
            throw new NotImplementedException();
        }

        public void UpdateForum(Forum forum)
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