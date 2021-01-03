using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

using Debie.Services;
using Debie.Models.DB;

namespace Debie.Components {
    public class NavbarComponent : ViewComponent {
        public NavbarComponent() {

        }
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}