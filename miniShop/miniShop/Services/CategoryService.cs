using Microsoft.AspNetCore.Authorization;
using miniShop.Data;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Services
{
    //[Authorize]
    public class CategoryService : ICategoryService
    {
        private VakifShopDbContext dbContext;

        public CategoryService(VakifShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Category category)
        {
           //var dbSet = dbContext.Set<Category>();
           
            dbContext.Add(category);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = dbContext.Categories.FirstOrDefault(x => x.Id == id);
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
        }

        public void Edit(Category category)
        {
            dbContext.Categories.Update(category);
            dbContext.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return dbContext.Categories.Find(id);
        }

        public bool IsCategoryExist(int id)
        {
            return dbContext.Categories.Any(c => c.Id == id);

        }
    }
}
