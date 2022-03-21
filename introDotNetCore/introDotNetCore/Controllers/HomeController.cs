using introDotNetCore.Models;
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
        public IActionResult Rsvp(RsvpModel rsvpModel)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks",rsvpModel);
             
            }
            //foreach (var item in ModelState.Keys)
            //{
            //    Console.WriteLine(item);
           
            //}
            //foreach (var item in ModelState.Values)
            //{
            //    Console.WriteLine(item.ValidationState);
            //}
            return View();
        }


    }
}
