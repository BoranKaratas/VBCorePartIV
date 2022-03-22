using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
    public class CartCollection
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public void AddProduct(Product product, int quantity)
        {

            var existingProduct = CartItems.Find(x => x.Product.Id == product.Id);
            if (existingProduct == null)
            {
                CartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                existingProduct.Quantity += quantity;
            }
        }

        public void Clear() => CartItems.Clear();
        public void Remove(int id) => CartItems.RemoveAll(x => x.Product.Id == id);
        public double GetTotalPrice() => CartItems.Sum(x => x.Product.Price.Value * (1 - x.Product.Discount) * x.Quantity);

    }
}
