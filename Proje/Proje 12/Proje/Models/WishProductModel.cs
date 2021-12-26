using Proje.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Models
{
    public class WishProductModel
    {
        private List<WishProduct> products = new List<WishProduct>();
        public List<WishProduct> Products => products;

        public void AddProduct(Product product)
        {
            var prdct = products.Where(x => x.Product.ProductId == product.ProductId).FirstOrDefault();
            //eklemek istediği ürünle aynı id ye sahip ürün var mı ?

            if (prdct == null)
            {
                products.Add(new WishProduct()
                {
                    Product = product,
                    
                }
                );


            }
            
        }

        public void RemoveProduct(Product product)
        {
            products.RemoveAll(x => x.Product.ProductId == product.ProductId);
        }

       
    }
    public class WishProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
       

    }
}

