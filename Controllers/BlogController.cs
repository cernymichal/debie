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
    public class BlogController : Controller {
        public BlogController() { }

        public IActionResult List() {
            return View(new List<Article>());
        }

        public IActionResult Detail() {
            return View(new Article());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
