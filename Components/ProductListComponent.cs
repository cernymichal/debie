using Microsoft.AspNetCore.Mvc;
using Debie.Models.DB;
using System.Collections.Generic;
using System.Linq;

namespace Debie.Components {
    public class ProductListComponent : ViewComponent {
        public IViewComponentResult Invoke(ICollection<Product> products, int count) {
            return View(products.Take(count));
        }
    }
}