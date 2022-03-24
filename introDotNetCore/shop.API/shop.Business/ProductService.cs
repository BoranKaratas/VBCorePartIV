using AutoMapper;
using Microsoft.EntityFrameworkCore;
using shop.DTOs.Requests;
using shop.DTOs.Responses;
using shop.Entities;
using Shop.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Business
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly vakifShopDbContext dbContext;

        public ProductService(vakifShopDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<int> Add(AddProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return product.Id;

        }

        public async Task<ProductListDisplayResponse> GetProduct(int id)
        {
            var product = await dbContext.Products.FindAsync(id);
            return mapper.Map<ProductListDisplayResponse>(product);
        }

        public async Task<ICollection<ProductListDisplayResponse>> GetProducts()
        {
            var products = await dbContext.Products.ToListAsync();
            //var list = new List<ProductListDisplayResponse>();
            //products.ForEach(p => list.Add(new ProductListDisplayResponse
            //{
            //    CategoryId = p.CategoryId,
            //    Discount = p.Discount,
            //    Id = p.Id,
            //    ImageUrl = p.ImageUrl,
            //    Name = p.Name,
            //    Price = p.Price
            //}));

            var result = mapper.Map<List<ProductListDisplayResponse>>(products);
            return result;
        }
    }
}
