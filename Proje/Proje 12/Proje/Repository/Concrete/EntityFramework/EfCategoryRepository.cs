using Microsoft.EntityFrameworkCore;
using Proje.Entity;
using Proje.Models;
using Proje.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proje.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(ElectronicContext context):base(context)
        {

        }
        public ElectronicContext EduraContext
        {
            get { return context as ElectronicContext; }
        }

        public IEnumerable<CategoryModel> GetAllWithProductCount()
        {
            return GetAll().Select(x => new CategoryModel()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Count = x.ProductCategories.Count()

            }) ;
        }

        public Category GetByName(string name)
        {
            return EduraContext.Categories.Where(x => x.CategoryName == name).FirstOrDefault();
        }

        public void RemoveFromCategory(int ProductId, int CategoryId)
        {
            var cmd = $"delete from ProductCategory where ,={ProductId} and CategoryId={CategoryId} ";
           
        }
    }
}
