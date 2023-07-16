using DAL.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    public interface IForumRepository
    {
        IEnumerable<Forum> GetAllFora();

        EntityEntry<Forum> CreateForum(Forum forum);

        void DeleteForum(Forum forum);

        void UpdateForum(Forum forum);
    }
}
