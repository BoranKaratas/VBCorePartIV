using miniShop.Data;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Services
{
    public class ProductService : IProductService
    {
        private VakifShopDbContext dbContext;

        public ProductService(VakifShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return product.Id;

        }

        public void Delete(int id)
        {
            Console.WriteLine("--> Ürün bulunuyor: FirstOrDefault");
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);

            dbContext.Products.Remove(product);
        }

        public Product GetProduct(int id)
        {
            Console.WriteLine("--> Ürün bulunuyor: Find");
            return dbContext.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }

        public bool IsExist(int id)
        {
            Console.WriteLine("--> Ürün bulunuyor: Find");
            return dbContext.Products.Any(x => x.Id == id);
        }

        public int Update(Product product)
        {
            //Dikkat! Burada kaç satırın güncellendiği bilgisi döndürülüyor:
            dbContext.Products.Update(product);
            return dbContext.SaveChanges();
        }
    }
}
