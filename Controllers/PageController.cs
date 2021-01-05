using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Debie.Models;
using Debie.Services.Repositories;

namespace Debie.Controllers {
    public class PageController : Controller {
        private readonly IProductRepository _ProductRepo;

        public PageController(IProductRepository productRepo) {
            _ProductRepo = productRepo;
        }

        public IActionResult Index() {
            var products = _ProductRepo.GetAll();
            var inSale = products.Where(p => p.Discounted).ToList();
            products.Reverse();
            var newArrivals = products.ToList();
            return View(new IndexView(inSale, newArrivals));
        }

        public IActionResult About() {
            return View();
        }

        public IActionResult Contact() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
