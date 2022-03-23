using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Services
{
   public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        int Add(Product product);
        int Update(Product product);
        void Delete(int id);
        bool IsExist(int id);


    }
}
