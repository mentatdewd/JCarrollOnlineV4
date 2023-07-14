using DAL.Repositories.Interfaces;

namespace DAL
{
    public interface IUnitOfWork
    {
        //ICustomerRepository Customers { get; }
        //IProductRepository Products { get; }
        //IOrdersRepository Orders { get; }
        IMicropostRepository Microposts { get; }

        int SaveChanges();
    }
}
