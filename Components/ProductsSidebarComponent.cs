using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;

using Debie.Services.Repositories;
using Debie.Models;

namespace Debie.Components {
    public class ProductsSidebarComponent : ViewComponent {
        private readonly IVendorRepository _VendorRepo;
        private readonly ICategoryRepository _CategoryRepo;
        public ProductsSidebarComponent(IVendorRepository vendorRepo, ICategoryRepository categoryRepo) {
            _VendorRepo = vendorRepo;
            _CategoryRepo = categoryRepo;
        }
        public IViewComponentResult Invoke(ProductSearch search) {
            ViewBag.Vendors = _VendorRepo.GetAll();
            ViewBag.Categories = _CategoryRepo.GetAll();

            return View(search);
        }
    }
}