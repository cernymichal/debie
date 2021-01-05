using Microsoft.AspNetCore.Mvc;
using Debie.Models.DB;
using System.Collections.Generic;
using System.Linq;

namespace Debie.Components {
    public class ProductListComponent : ViewComponent {
        public IViewComponentResult Invoke(List<Product> products, int count, int columns) {
            ViewBag.Columns = columns;
            return View(products.Take(count).ToList());
        }
    }
}