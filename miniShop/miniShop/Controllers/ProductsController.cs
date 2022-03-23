using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using miniShop.Models;
using miniShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        //[AllowAnonymous]
        public IActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }
       
        public IActionResult Create()
        {
            List<SelectListItem> selectListItems = getSelectListItems();

            ViewBag.Categories = selectListItems;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name","Price","CategoryId","Discount","ImageUrl")]Product product)
        {
            if (ModelState.IsValid)
            {
                var result = productService.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            if (productService.IsExist(id))
            {
                var product = productService.GetProduct(id);
                List<SelectListItem> selectListItems = getSelectListItems();
                ViewBag.Categories = selectListItems;
                return View(product);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Update(product);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        private List<SelectListItem> getSelectListItems()
        {
            var categories = categoryService.GetCategories();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            categories.ForEach(cat => selectListItems.Add(new SelectListItem { Text = cat.Name, Value = cat.Id.ToString() }));
            return selectListItems;
        }
    }
}
