using Proje.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages() 
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            //örneğin 10 ürünümüz olsun her sayfada 3 ürün göstermek istersek 10/3 =3,33 yaklaşık olarak 4 sayfaya ihtiyacımız olacak
        }
    }
    public class ProductListModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}
