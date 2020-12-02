using Microsoft.AspNetCore.Mvc;
using Debie.Models.DB;

namespace Debie.Components {
    public class BlogSidebarComponent : ViewComponent {
        public IViewComponentResult Invoke() {

            return View();
        }
    }
}