using Proje.Entity;
using Proje.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proje.Repository.Concrete.EntityFramework
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductRepository
    {

        public EfProductRepository(EduraContext context):base(context)
        {

        }
        public EduraContext EduraContext
        {
            get { return context as EduraContext; }
        }
        public List<Product> GetTop5Products()
        {
            return EduraContext.Products.OrderByDescending(x => x.ProductId).Take(5).ToList();
        }
    }
}
