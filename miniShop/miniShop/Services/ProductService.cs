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
        public Product GetProduct(int id)
        {
            return dbContext.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }
    }
}
