using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Debie.Models;
using Debie.Models.DB;

namespace Debie.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _Logger;
        private readonly DebieContext _Context;

        public HomeController(ILogger<HomeController> logger, DebieContext context) {
            _Logger = logger;
            _Context = context;
        }

        public IActionResult Index() {
            Console.WriteLine(_Context.Products.Count());
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
