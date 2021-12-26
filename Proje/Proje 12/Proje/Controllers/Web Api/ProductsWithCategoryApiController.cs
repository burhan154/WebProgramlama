using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje.Entity;
using Proje.Repository.Abstract;
using Proje.Repository.Concrete.EntityFramework;

namespace Proje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsWithCategoryApiController : ControllerBase
    {
        private readonly ElectronicContext _context;

        public ProductsWithCategoryApiController(ElectronicContext context)
        {
            _context = context;

        }

        // GET: api/ProductsWithCategoryApi/5
        [HttpGet("{categoryName}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string categoryName)
        {
            ///api/productswithcategoryapi/Electronics
        

            var product = await _context.Products.Include(x => x.Images)
                .Include(x => x.Attributes)
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category)
                .Where(x => x.ProductCategories.Any(a => a.Category.CategoryName == categoryName)).ToListAsync();
            if (product == null)
            {
                return NotFound();
            }

            return product;
        } 

    }
}
