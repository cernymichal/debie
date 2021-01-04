using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

using Debie.Services.Repositories;
using Debie.Models.DB;

namespace Debie.Components {
    public class NavbarComponent : ViewComponent {
        private readonly ICategoryRepository _CategoryRepo;
        public NavbarComponent(ICategoryRepository categoryRepo) {
            _CategoryRepo = categoryRepo;
        }
        public IViewComponentResult Invoke() {
            ViewBag.Categories = _CategoryRepo.GetAll();
            return View();
        }
    }
}