using Proje.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Models
{
    public class ProductModel
    {
        public Product Product { get; set; }
        public ProductAttribute ProductAttributes { get; set; }
        public Category Categories { get; set; }
    }
}
