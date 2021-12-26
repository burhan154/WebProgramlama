using Proje.Entity;
using Proje.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace Proje.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork; /*unit Of work aracılığıyla tüm repository lere ulaşabiliyoruz ve bu repository lerin kullandığı tek bir db
                                          context var.*/
        public HomeController(IProductRepository productRepository,IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View(_unitOfWork.Products.GetAll().Where(x=>x.IsApproved&& x.IsHome).ToList());
        }
        public IActionResult Details(int id)
        {
            return View(_productRepository.Get(id));
        }

        public IActionResult Create()
        {
            var product = new Product() { ProductName = "Yeni Urun", Price = 1000 };
            _unitOfWork.Products.Add(product);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]

        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return LocalRedirect(returnUrl);
        }
    }
}
