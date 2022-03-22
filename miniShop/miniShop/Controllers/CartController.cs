using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miniShop.Models;
using miniShop.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService productService;

        public CartController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            var cartCollection = getCartCollectionFromSession();
            return View(cartCollection);
        }

        public IActionResult AddToCart(int id)
        {
            var product = productService.GetProduct(id);
            if (product == null)
            {
                return Json("Ürün bulunamadı");
            }

            CartCollection cartCollection = getCartCollectionFromSession();
            cartCollection.AddProduct(product, 1);
            saveToSession(cartCollection);

            return Json("Ok"+" "+id);
        }

        private void saveToSession(CartCollection cartCollection)
        {
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartCollection));
        }

        private CartCollection getCartCollectionFromSession()
        {
            //Session sadece sepete ilk ürün eklendiğinde oluşmalı.
            CartCollection cartCollection = null;
            if (HttpContext.Session.GetString("cart") == null)
            {
                cartCollection = new CartCollection();

            }
            else
            {
                cartCollection = JsonConvert.DeserializeObject<CartCollection>(HttpContext.Session.GetString("cart"));
            }

           
            return cartCollection;


        }
    }
}
