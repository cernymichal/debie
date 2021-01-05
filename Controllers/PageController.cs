using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Debie.Models;
using Debie.Models.DB;
using Debie.Services.Repositories;

namespace Debie.Controllers {
    public class PageController : Controller {
        private readonly IProductRepository _ProductRepo;
        private readonly IFeedbackRepository _FeedbackRepo;

        public PageController(IProductRepository productRepo, IFeedbackRepository feedbackRepo) {
            _ProductRepo = productRepo;
            _FeedbackRepo = feedbackRepo;
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

        public IActionResult Contact(Feedback feedback) {
            return View(feedback);
        }

        [HttpPost, Route("{controller}/Contact")]
        public IActionResult ContactFeedback(Feedback feedback) {
            if (ModelState.IsValid) {
                feedback.Created = DateTime.UtcNow;
                _FeedbackRepo.Insert(feedback);
                _FeedbackRepo.Save();
            }
            else
                return RedirectToAction("Contact", feedback);

            return RedirectToAction("Contact");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
