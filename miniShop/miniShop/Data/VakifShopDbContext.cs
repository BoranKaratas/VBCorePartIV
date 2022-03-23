using Microsoft.EntityFrameworkCore;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Data
{
    public class VakifShopDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer()
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public VakifShopDbContext(DbContextOptions<VakifShopDbContext> options) : base(options)
        {
            //Database.E
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired()
                                                                .HasMaxLength(150);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);
            //Seeding:
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "test", Discount = 0 });



        }




        public DbSet<miniShop.Models.UserLoginModel> UserLoginModel { get; set; }
    }
}
