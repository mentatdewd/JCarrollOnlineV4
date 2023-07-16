using DAL.Repositories;
using DAL.Repositories.Interfaces;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IMicropostRepository _microposts;
        private IForumRepository _fora;
        private IForumThreadEntryRepository _forumThreadEntry;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IMicropostRepository Microposts
        {
            get
            {
                _microposts ??= new MicropostRepository(_context);

                return _microposts;
            }
        }

        public IForumRepository Fora
        {
            get
            {
                _fora ??= new ForumRepository(_context);
                return _fora;
            }
        }

        public IForumThreadEntryRepository ForumThreadEntry
        {
            get
            {
                _forumThreadEntry ??= new ForumThreadEntryRepository(_context);
                return _forumThreadEntry;
            }
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
