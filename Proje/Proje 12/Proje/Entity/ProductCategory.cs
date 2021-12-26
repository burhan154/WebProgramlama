using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Entity
{
    public class ProductCategory
    {
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }

    }
}
