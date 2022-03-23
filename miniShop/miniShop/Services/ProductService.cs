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
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);
            
            dbContext.Products.Remove()
        }

        public Product GetProduct(int id)
        {
            return dbContext.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }

        public bool IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
