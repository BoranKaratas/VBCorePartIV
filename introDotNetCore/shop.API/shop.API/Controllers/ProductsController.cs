using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productsDto = await productService.GetProducts();
            return Ok(productsDto);

           
        }

    }
}
