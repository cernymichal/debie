using Microsoft.AspNetCore.Mvc;
using Debie.Models.DB;

namespace Debie.Components {
    public class ProductComponent : ViewComponent {
        public IViewComponentResult Invoke(Product product) {
            ViewBag.Product = product;
            return View();
        }
    }
}