using Proje.Entity;
using Proje.Models;
using Proje.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Proje.IdentityCore;
using Microsoft.AspNetCore.Identity;

namespace Proje.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment webHostEnvironment;
        private UserManager<ApplicationUser> userManager;
        public AdminController(IUnitOfWork _unitOfWork, IWebHostEnvironment _webHostEnvironment, UserManager<ApplicationUser> _userManager)
        {
            unitOfWork = _unitOfWork;
            webHostEnvironment = _webHostEnvironment;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var entity = unitOfWork.Categories.GetAll()
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Product)
                .Where(x => x.CategoryId == id).Select(x => new AdminEditCategoryModel()
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    Products = x.ProductCategories.Select(a => new AdminEditCategoryProduct()
                    {
                        ProductId=a.ProductId,
                        ProductName=a.Product.ProductName,
                        Image=a.Product.Image,
                        IsAprroved=a.Product.IsApproved,
                        IsFeatured=a.Product.IsFeatured,
                        IsHome=a.Product.IsHome

                    }).ToList()

                }).FirstOrDefault();
                 return View(entity);
        }

        [HttpPost]
        public IActionResult EditCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Categories.Edit(entity);
                unitOfWork.SaveChanges();
                return RedirectToAction("CatalogList");
            }

            return View("Error");
        }

        public IActionResult RemoveFromCategory(int ProductId,int CategoryId)
        {
            //burada ilişkiyi kaldırıyorum ürünü silmiyorum
            if (ModelState.IsValid)
            {
                //silme
                
                return Ok();
            }
            return BadRequest();
        }

        public IActionResult CatalogList()
        {
            var model = new CatalogListModel() {
                Categories = unitOfWork.Categories.GetAll().ToList(),
                Products=unitOfWork.Products.GetAll().ToList()
            };
            return View(model);
        }
        public IActionResult ProductList()
        {
            var model = new CatalogListModel()
            {
                Categories = unitOfWork.Categories.GetAll().ToList(),
                Products = unitOfWork.Products.GetAll().ToList()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Categories.Add(entity);
                unitOfWork.SaveChanges();

                return RedirectToAction("CatalogList");
            }
            return BadRequest();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath +=  file.FileName;
            string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }



        [HttpGet]
        public IActionResult AddProduct(IFormFile CoverPhoto, IEnumerable<IFormFile> formFiles)
        {
            ViewBag.Categories = new SelectList(unitOfWork.Categories.GetAll(),"CategoryId","CategoryName");
            ViewBag.CoverPhoto = CoverPhoto;
            ViewBag.formFiles = formFiles;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product entity,IFormFile CoverPhoto,IEnumerable<IFormFile> formFiles)
        {
            if (CoverPhoto!=null)
            {
                string folder = "images/products/tn/";
                await UploadImage(folder, CoverPhoto);
                entity.Image = CoverPhoto.FileName;
            }
            if (formFiles != null)
            {
                string folder = "images/products/";
                entity.Images = new List<Image>();

                foreach (var file in formFiles)
                {
                    var image = new Image()
                    {
                        ImageName = file.FileName,
                        
                    };
                    await UploadImage(folder, file);
                    entity.Images.Add(image);
                    
                }
            }

            entity.DateAdded = DateTime.Now;
            unitOfWork.Products.Add(entity);
            unitOfWork.SaveChanges();
            return RedirectToAction("ProductList");
           
        }

        [HttpGet]
        public IActionResult EditProductAsync(int id)
        {
            ViewBag.Categories = new SelectList(unitOfWork.Categories.GetAll(), "CategoryId", "CategoryName");
            var entity = unitOfWork.Products.GetAll()
                .Where(x => x.ProductId == id)
                .Include(x => x.Attributes)
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category)
                .FirstOrDefault();
     
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> EditProductAsync(Product entity, IFormFile CoverPhoto)
        {
            string prevPath = entity.Image;
            if (CoverPhoto != null)
            {
                string folder = "images/products/tn/";
                await UploadImage(folder, CoverPhoto);
                entity.Image = CoverPhoto.FileName;
            }
            String filepath = Path.Combine(webHostEnvironment.WebRootPath,"images", prevPath);
            
                if (System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);

                }
            
             unitOfWork.Products.Edit(entity);
             unitOfWork.SaveChanges();
            
             return RedirectToAction("ProductList");
           
        }
        public IActionResult ListUsers()
        {
            return View(userManager.Users.ToList());
        }
        public IActionResult Delete(int id)
        {
            var entity = unitOfWork.Products.GetAll().Where(x => x.ProductId == id).FirstOrDefault();
            unitOfWork.Products.Delete(entity);
            unitOfWork.SaveChanges();
            return RedirectToAction("CatalogList");
        }

        public IActionResult DeleteCategory(int id)
        {
            var entity = unitOfWork.Categories.GetAll().Where(x => x.CategoryId == id).FirstOrDefault();
            unitOfWork.Categories.Delete(entity);
            unitOfWork.SaveChanges();
            return RedirectToAction("CatalogList");
        }
    }
}
