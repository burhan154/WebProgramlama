using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Entity
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } //navigation property


    }
}
