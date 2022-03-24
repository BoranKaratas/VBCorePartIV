using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using shop.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Filters
{
    public class ItemExistsFilter : IAsyncActionFilter
    {
        private readonly IProductService productService;

        public ItemExistsFilter(IProductService productService)
        {
            this.productService = productService;
        }
        public  async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //bu filtrenin kullanıldığı action'da belirtilen id'li değer var mı?
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new NotFoundResult();
                return;
            }

            if (!(context.ActionArguments["id"] is int id))
            {
                context.Result = new NotFoundResult();
                return;
            }

            var isExist = await productService.isProductExist(id);
            if (!isExist)
            {
                context.Result = new NotFoundObjectResult(new { message = $"{id} id'li bir ürün bulunamadı" });
                return;
            }

            await next();

        }

    }
}
