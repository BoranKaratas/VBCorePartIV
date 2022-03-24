using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Business;
using shop.DTOs.Requests;
using shop.DTOs.Responses;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            ProductListDisplayResponse productListDisplay = await productService.GetProduct(id);
            if (productListDisplay == null)
            {
                return NotFound(new { message = $"{id} id'li bir ürün bulunamadı" });
            }

            return Ok(productListDisplay);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewProduct(AddProductRequest request)
        {
            if (ModelState.IsValid)
            {
                int id = await productService.Add(request);
                return CreatedAtAction(nameof(GetProduct), new { id = id }, null);
            }

            return BadRequest(ModelState);
        }

    }
}
