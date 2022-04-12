using FiltersPro.Models;
using FiltersPro.Models.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[CacheResourceFilter]
        [TypeFilter(typeof(CachReSourceFilter))]
        public IActionResult Index()
        {
            return View("Index", $"This is a text and gnerated at:{DateTime.Now.TimeOfDay}");
        }

        [AuthorizeActionFilter("Admin")]
        public IActionResult Edit()
        {
            return View();
        }

        [AuthorizeActionFilter("User")]
        public IActionResult List()
        {
            return View();
        }

        [ValidModelAttrbute]
        [HttpPost]
        public IActionResult ProductEdit([FromForm] ProductViewModelcs productViewModelcs)
        {
            return View();
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        public IActionResult Error()
        {
            throw new NotImplementedException();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [AddHeaderFilter]
        public IActionResult Result()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
