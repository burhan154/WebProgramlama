using Proje.Models;
using Proje.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Infrastructure;
using Proje.Entity;

namespace Proje.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 8;
        private IProductRepository repository;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(string search, int page = 1) 
        {
            var products = repository.GetAll(); 
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(x => x.ProductName.Contains(search));
            }

            var count = products.Count();
          
            return View(
                new ProductListModel()
                {
                    Products = products,
                    PagingInfo = new PagingInfo()
                    {
                        SearchPage = search,
                        CurrentPage = page,
                        ItemsPerPage = count,
                        TotalItems = count
                    }
                }

                );
        }
        public IActionResult List(string category,int page=1) //varsayılan bir page girilmezse 1.sayfa ürünlerini listeleyecek.
        {
            //category nullable olabilir.
            var products = repository.GetAll(); //IQuaryable idi. Dolayısıyla bunu filtreleme işlemlerine tabi tutabilirim.

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Include(x => x.ProductCategories) /*product nesnesinin içindeyim. Tek bir sorgu içersinde ilgili
                                                                      productcategory ler ve productcategorylere bağlı olan categorylere ulaştım.*/
                .ThenInclude(x => x.Category)
                .Where(x => x.ProductCategories.Any(a => a.Category.CategoryName == category));
            }

            var count = products.Count();
            products = products.Skip((page-1)*8).Take(8);//veritabanında ki en başdaki kayıtların 5 i değilde ikinci 5 i alınıyor.
            //örneğin 1.sayfadayız 0 kayıt öteleyeceğiz ve 2 ürün alacağız. Ben her sayfada 8 ürün gösterilmesini istiyorum.

            return View(
                new ProductListModel()
                {
                    Products = products,
                    PagingInfo =new PagingInfo()
                    {
                        CurrentPage=page,
                        ItemsPerPage= PageSize,
                        TotalItems=count
                    }
                }

                ) ;
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            /*tüm ürünlerden id ile eşlenen ürünü alıyor sonra bu ürünün resimlerini,özelliklerini alıyor ve kategorilerini de alıyor sonrada
             category sınıfını alıyor*/
            return View(
                repository.GetAll()
                .Where(x => x.ProductId == id)
                .Include(x => x.Images)
                .Include(x => x.Attributes)
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductDetailsModel()
                {
                    Product=x,
                    ProductImages=x.Images,
                    ProductAttributes=x.Attributes,
                    Categories=x.ProductCategories.Select(a=>a.Category).ToList()
                })
                .FirstOrDefault()
                );
        }
        [HttpPost]
        public IActionResult AddToWishList(int ProductId)
        {
            var product = repository.Get(ProductId);
            if (product != null)
            {
                var wishProduct = GetWishedProduct();
                wishProduct.AddProduct(product);
                SaveWishProduct(wishProduct);
            }

            return RedirectToAction("List");
        }

        public IActionResult RemoveFromWishList(int ProductId)
        {
            var product = repository.Get(ProductId);

            if (product != null)
            {
                var wishProductModel = GetWishedProduct();
                wishProductModel.RemoveProduct(product);
                SaveWishProduct(wishProductModel);
            }
            return RedirectToAction("WishList");
        }
        public IActionResult WishList()
        {
            return View(GetWishedProduct());
        }
        private void SaveWishProduct(WishProductModel product) // cart nesnesini session içerine direkt aktaramıyorum.Dolayısıyla sınıfdan jsona aktarma yapacağız.
        {
            HttpContext.Session.SetJson("WishProductModel", product); // Cart diye değişken tanımladım ve bu benim cart nesnemi serialize edip bu değişkene json formatında atıcak
        }

        private WishProductModel GetWishedProduct()
        {
            return HttpContext.Session.GetJson<WishProductModel>("WishProductModel") ?? new WishProductModel();
            //new Cart() yapmamızın nedeni eğerki getCart bize boş bir değer döndürürse boş da olsa bir nesne gönderelim diye yazdık aksi halde exception alırız.
        }
    }
}
