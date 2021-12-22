using Proje.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Repository.Concrete.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly EduraContext _dbContext;
        public EfUnitOfWork(EduraContext dbContext)
        {
            _dbContext = dbContext?? throw new ArgumentNullException("dbContext cannot NULL!!");
        }

        private IProductRepository _products;
        private ICategoryRepository _categories;
        private IOrderRepository _orders;
        public IProductRepository Products
        {
            get
            {
                return _products ?? (_products = new EfProductRepository(_dbContext));

            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                return _categories ?? (_categories = new EfCategoryRepository(_dbContext));
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                return _orders ?? (_orders = new EfOrderRepository(_dbContext));
            }
        }
       
        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        
    }
}
