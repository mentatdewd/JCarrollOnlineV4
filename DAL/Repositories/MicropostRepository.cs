using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class MicropostRepository : Repository<Micropost>, IMicropostRepository
    {
        public MicropostRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public IEnumerable<Micropost> GetAllMicroposts(ApplicationUser user)
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
            _appDbContext.Users.Update(user);
        }
        private ApplicationDbContext _appDbContext;
        public ApplicationDbContext AppDbContext
        {
            get => _appDbContext;
            init => _appDbContext = value;
        }
    }
}