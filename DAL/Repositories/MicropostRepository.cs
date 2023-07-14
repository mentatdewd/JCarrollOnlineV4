using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class MicropostRepository : Repository<Micropost>, IMicropostRepository
    {
        public MicropostRepository(ApplicationDbContext context) : base(context)
        { }

        public IEnumerable<Micropost> GetAllMicroposts()
        {
            throw new NotImplementedException();
        }

        public void  AddMicropost(ApplicationUser user, Micropost micropost)
        {
            if(user.MicroPosts == null)
            {
                user.MicroPosts = new List<Micropost>();
            }

            user.MicroPosts.Add(micropost);
            _appContext.Users.Update(user);
        }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

    }
}