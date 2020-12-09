using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;

using Debie.Services.Repositories;
using Debie.Models.DB;

namespace Debie.Components {
    public class ProductsSidebarComponent : ViewComponent {
        private readonly IVendorRepository _VendorRepo;
        public ProductsSidebarComponent(IVendorRepository vendorRepo) {
            _VendorRepo = vendorRepo;
        }
        public IViewComponentResult Invoke() {
            ViewBag.Vendors = _VendorRepo.GetAll();

            return View();
        }
    }
}