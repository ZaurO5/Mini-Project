using Core.Constants;
using Data.Repositories.Concrete;
using Data.Repository.Concrete;
using Data.UnitOfWork.Abstract;
using System;

namespace Data.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public readonly AdminRepository Admins;
        public readonly CategoryRepository Categories;
        public readonly CustomerRepository Customers;
        public readonly OrderRepository Orders;
        public readonly ProductRepository Products;
        public readonly SellerRepository Sellers;

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
            Admins = new AdminRepository(_context);
            Categories = new CategoryRepository(_context);
            Customers = new CustomerRepository(_context);
            Orders = new OrderRepository(_context);
            Products = new ProductRepository(_context);
            Sellers = new SellerRepository(_context);
        }

        public void Commit(string title)
        {
            try
            {
                _context.SaveChanges();
                Messages.SuccessMessage(title);
            }
            catch (Exception)
            {
                Messages.ErrorHasOccuredMessage();
            }
        }
    }
}
