using Proje.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Components
{
    public class Categories:ViewComponent
    {
        private ICategoryRepository repository;
        public Categories(ICategoryRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View(repository.GetAllWithProductCount());
        }
    }
}
