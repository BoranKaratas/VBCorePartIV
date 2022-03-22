using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Services
{
   public interface ICategoryService
    {
        List<Category> GetCategories();
        void Add(Category category);
        void Edit(Category category);
        void Delete(int id);

        Category GetCategory(int id);
        bool IsCategoryExist(int id);


    }
}
