using Proje.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Models
{

    public class Cart
    {
        private List<CartLine> products = new List<CartLine>();
        public List<CartLine> Products => products;

        public void AddProduct(Product product,int quantity)
        {
            var prdct = products.Where(x => x.Product.ProductId == product.ProductId).FirstOrDefault();
            //eklemek istediği ürünle aynı id ye sahip ürün var mı ?

            if(prdct==null)
            {
                products.Add(new CartLine()
                {
                    Product=product,
                    Quantity=quantity
                }
                );


            }
            else
            {
                prdct.Quantity += quantity;
            }
        }

        public void RemoveProduct(Product product)
        {
            products.RemoveAll(x => x.Product.ProductId == product.ProductId);
        }

        public double TotalPrice()
        {
            return products.Sum(x => x.Product.Price * x.Quantity);
        }

        public void ClearAll()
        {
            products.Clear();
        }
    }
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product  Product { get; set; }
        public int Quantity { get; set; }

    }
}
