using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMVCTest.Models;
using CoreMVCTest.Utilities;

namespace CoreMVCTest.Controllers
{
    public class HomeController : Controller
    {
        ILog _log;

        public HomeController(ILog log)
        {
            _log = log;
        }

        public IActionResult Index()
        {
            _log.info("Constructor injection");
            return View();
        }

        public IActionResult About([FromServices] ILog log)
        {
            log.info("Method injection");
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
