using Proje.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proje.Repository.Abstract
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        //Extradan product a özel bir metod tanımlayabiliriz.
        List<Product> GetTop5Products();
    }
}
