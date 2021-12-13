using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Entity
{
    public class ProductAttribute
    {
        public int ProductAttributeId { get; set; }
        public string Attribute { get; set; } //örnek olarak işlemci
        public string Value { get; set; } // i7 işlemci
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
