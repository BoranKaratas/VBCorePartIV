using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace introDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            ViewBag.Name = "Türkay";

            return View();
        }

        [HttpGet]
        public IActionResult Rsvp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Rsvp(IFormCollection forms)
        {
            return View();
        }


    }
}
