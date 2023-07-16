using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    public interface IMicropostRepository : IRepository<Micropost>
    {
           IEnumerable<Micropost> GetAllMicroposts(ApplicationUser user);
            void AddMicropost(ApplicationUser user, Micropost micropost);
    }
}
