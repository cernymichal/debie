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
    public class CartController : Controller {
        public CartController() { }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Customer() {
            return View();
        }

        public IActionResult Shipping() {
            return View();
        }

        public IActionResult Payment() {
            return View();
        }

        public IActionResult Complete() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
