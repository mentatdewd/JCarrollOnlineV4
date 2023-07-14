using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IMicropostRepository : IRepository<Micropost>
    {
           IEnumerable<Micropost> GetAllMicroposts();
            void AddMicropost(ApplicationUser user, Micropost micropost);
    }
}
