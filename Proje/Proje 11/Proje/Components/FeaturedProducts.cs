using Proje.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Components
{
    public class FeaturedProducts:ViewComponent
    {
        private IProductRepository repository;
        public FeaturedProducts(IProductRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            return View(repository.GetAll().Where(x=>x.IsFeatured&&x.IsApproved).ToList());
        }
    }
}
