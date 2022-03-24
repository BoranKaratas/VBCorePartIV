using shop.DTOs.Requests;
using shop.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Business
{
    public interface IProductService
    {
        Task<ICollection<ProductListDisplayResponse>> GetProducts();
        Task<ProductListDisplayResponse> GetProduct(int id);
        Task<int> Add(AddProductRequest request);
        Task<bool> isProductExist(int id);      
        Task UpdateAsync(UpdateProductRequest request);
        Task Delete(int id);
    }
}
