using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IMicropostRepository _microposts;
        //private ICustomerRepository _customers;
        //private IProductRepository _products;
        //private IOrdersRepository _orders;

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

        //public ICustomerRepository Customers
        //{
        //    get
        //    {
        //        _customers ??= new CustomerRepository(_context);

        //        return _customers;
        //    }
        //}

        //public IProductRepository Products
        //{
        //    get
        //    {
        //        _products ??= new ProductRepository(_context);

        //        return _products;
        //    }
        //}

        //public IOrdersRepository Orders
        //{
        //    get
        //    {
        //        _orders ??= new OrdersRepository(_context);

        //        return _orders;
        //    }
        //}

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
