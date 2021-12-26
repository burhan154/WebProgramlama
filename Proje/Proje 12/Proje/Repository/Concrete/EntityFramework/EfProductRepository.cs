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

        public EfProductRepository(ElectronicContext context):base(context)
        {

        }
        public ElectronicContext EduraContext
        {
            get { return context as ElectronicContext; }
        }


        public List<Product> GetTop5Products()
        {
            return EduraContext.Products.OrderByDescending(x => x.ProductId).Take(5).ToList();
        }
        
        
    }
}
