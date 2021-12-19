﻿using Proje.Entity;
using Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proje.Repository.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Category GetByName(string name);
        IEnumerable<CategoryModel> GetAllWithProductCount();
        void RemoveFromCategory(int ProductId,int CategoryId);
    }
}
