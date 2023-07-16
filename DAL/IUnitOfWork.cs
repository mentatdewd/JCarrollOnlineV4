using DAL.Repositories.Interfaces;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        IMicropostRepository Microposts { get; }

        IForumRepository Fora { get; }

        Task<int> SaveChanges();
    }
}
