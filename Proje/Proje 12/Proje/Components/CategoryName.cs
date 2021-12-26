using Microsoft.AspNetCore.Mvc;
using Proje.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Components
{
    public class CategoryName : ViewComponent
    {
        private ICategoryRepository repository;
        public CategoryName(ICategoryRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View(repository.GetAll().Take(4));
        }
    }
}
