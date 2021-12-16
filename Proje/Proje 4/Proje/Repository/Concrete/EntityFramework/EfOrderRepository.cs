using Proje.Entity;
using Proje.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Repository.Concrete.EntityFramework
{
    public class EfOrderRepository:EfGenericRepository<Order>,IOrderRepository
    {
        public EfOrderRepository(EduraContext context):base(context)
        {

        }
    }
}
