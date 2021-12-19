using Proje.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Models
{
    public class AdminEditCategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<AdminEditCategoryProduct> Products { get; set; }

        
    }
}
