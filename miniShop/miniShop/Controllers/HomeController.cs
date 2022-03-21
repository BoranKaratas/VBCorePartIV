using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product{ Id=1, Name="Mac Book Pro", Discount=0.25, Price=20000, ImageUrl="https://productimages.hepsiburada.net/s/49/222-222/10983949893682.jpg"},

              new Product{ Id=2, Name="Dell", Discount=0.25, Price=20000, ImageUrl="https://productimages.hepsiburada.net/s/49/222-222/10983949893682.jpg"},

              new Product{ Id=3, Name="Huawei", Discount=0.25, Price=20000, ImageUrl="https://productimages.hepsiburada.net/s/49/222-222/10983949893682.jpg"},

              new Product{ Id=4, Name="Xiaomi", Discount=0.25, Price=20000, ImageUrl="https://productimages.hepsiburada.net/s/49/222-222/10983949893682.jpg"},

              new Product{ Id=5, Name="Lenovo", Discount=0.25, Price=20000, ImageUrl="https://productimages.hepsiburada.net/s/49/222-222/10983949893682.jpg"},

            };
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
