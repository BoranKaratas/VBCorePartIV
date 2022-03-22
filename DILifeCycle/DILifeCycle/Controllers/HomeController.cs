using DILifeCycle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DILifeCycle.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScoped scoped;
        private readonly ISingleton singleton;
        private readonly ITransient transient;
        private readonly GuidService guidService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IScoped scoped, ISingleton singleton, ITransient transient, GuidService guidService)
        {
            this.scoped = scoped;
            this.singleton = singleton;
            this.transient = transient;
            this.guidService = guidService;

            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Scope = scoped.GetGuid();
            ViewBag.Singleton = singleton.GetGuid();
            ViewBag.Transient = transient.GetGuid();
            //
            ViewBag.ServiceScope = guidService.ScopedGuid;
            ViewBag.ServiceSingleton = guidService.SingletonGuid;
            ViewBag.ServiceTransient = guidService.TransientGuid;
            return View();
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
