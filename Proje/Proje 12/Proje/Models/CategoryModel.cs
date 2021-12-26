using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Models
{
    public class CategoryModel
    {
       
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Count { get; set; } //her kategoriye ait ürün sayısı gelicek.
    }
}
