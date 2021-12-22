using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Repository.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }
        int SaveChanges();
    }
}
