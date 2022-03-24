using shop.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Business
{
   public  interface IProductService
    {
        ICollection<ProductListDisplayResponse> GetProducts();
    }
}
