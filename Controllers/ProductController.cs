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
    public class ProductController : Controller {
        private readonly DebieContext _Context;

        public ProductController(DebieContext context) {
            _Context = context;
        }

        public IActionResult List() {
            return View(_Context.Products);
        }

        public IActionResult Detail() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
