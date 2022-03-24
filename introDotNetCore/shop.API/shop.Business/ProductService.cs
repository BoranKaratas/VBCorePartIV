using AutoMapper;
using Microsoft.EntityFrameworkCore;
using shop.DTOs.Responses;
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
