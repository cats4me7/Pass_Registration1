using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BasicApp1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HelloWorld()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Company Information.";

            return View();
        }

       
        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact the Company.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
