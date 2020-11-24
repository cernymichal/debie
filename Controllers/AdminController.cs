
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using Debie.Models;
using Debie.Models.DB;
using Debie.Services;
using Debie.Services.Repositories;

namespace Debie.Controllers {
    [Authorize]
    public class AdminController : Controller {
        private readonly ILoginService _LoginService;
        private readonly IArticleRepository _ArticleRepo;
        private readonly IOrderRepository _OrderRepo;
        private readonly IProductRepository _ProductRepo;
        private readonly IUserRepository _UserRepo;
        private readonly IVendorRepository _VendorRepo;

        public AdminController(ILoginService loginService, IArticleRepository articleRepo, IOrderRepository orderRepo, IProductRepository productRepo, IUserRepository userRepo, IVendorRepository vendorRepo) {
            _LoginService = loginService;
            _ArticleRepo = articleRepo;
            _OrderRepo = orderRepo;
            _ProductRepo = productRepo;
            _UserRepo = userRepo;
            _VendorRepo = vendorRepo;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login(string returnUrl = "") {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index");

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Login(Login login, string returnUrl = "") {
            if (ModelState.IsValid) {
                var invalid = false;
                try {
                    _LoginService.Login(login);
                }
                catch (CryptographicException) {
                    ViewBag.ErrorMessage = "Wrong username or password.";
                    invalid = true;
                }

                if (!invalid)
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(login);
        }

        public IActionResult Logout() {
            _LoginService.Logout();
            return RedirectToAction("Index", "Page");
        }

        public IActionResult Index() {
            return RedirectToAction("Products");
        }

        public IActionResult Products(string query = null) {
            ViewBag.Query = query;
            if (!string.IsNullOrEmpty(query))
                return View(_ProductRepo.GetAll().Where(p => p.Search(query)));
            return View(_ProductRepo.GetAll());
        }

        [HttpGet, Route("{controller}/Product/{id?}")]
        public IActionResult Product(int? id = null) {
            ViewBag.Vendors = _VendorRepo.GetAll();

            var product = _ProductRepo.GetByID(id);
            return View(ProductForm.FromModel(product) ?? new ProductForm());
        }

        [HttpPost, Route("{controller}/Product/{id?}")]
        public IActionResult ProductEdit(ProductForm productForm) {
            ViewBag.Vendors = _VendorRepo.GetAll();

            if (ModelState.IsValid) {
                var product = _ProductRepo.GetByID(productForm.ID);
                var passed = true;
                try {
                    _ProductRepo.Update(productForm.ToModel(product));
                }
                catch (System.FormatException) {
                    ViewBag.Alert = "Couldn't parse";
                    passed = false;
                }

                if (passed) {
                    _ProductRepo.Save();
                    ViewBag.Alert = "Saved!";
                    productForm = ProductForm.FromModel(product);
                }
            }

            return View("Product", productForm);
        }

        public IActionResult ProductDelete(int id) {
            _ProductRepo.Delete(_ProductRepo.GetByID(id));
            _ProductRepo.Save();
            return RedirectToAction("Products");
        }

        public IActionResult Articles(string query = null) {
            ViewBag.Query = query;
            if (!string.IsNullOrEmpty(query))
                return View(_ArticleRepo.GetAll().Where(a => a.Search(query)));
            return View(_ArticleRepo.GetAll());
        }

        [HttpGet, Route("{controller}/Article/{id?}")]
        public IActionResult Article(int? id = null) {
            ViewBag.Users = _UserRepo.GetAll();

            var article = _ArticleRepo.GetByID(id);
            return View(ArticleForm.FromModel(article) ?? new ArticleForm());
        }

        [HttpPost, Route("{controller}/Article/{id?}")]
        public IActionResult ArticleEdit(ArticleForm articleForm) {
            ViewBag.Users = _UserRepo.GetAll();

            if (Request.Form.Files["cover-image"] != null) {
                var article = _ArticleRepo.GetByID(articleForm.ID);
                article.Image = new Image {
                    ContentType = Request.Form.Files["cover-image"].ContentType,
                    Data = new byte[Request.Form.Files["cover-image"].Length]
                };

                Request.Form.Files["cover-image"].OpenReadStream().Read(article.Image.Data, 0, article.Image.Data.Length);

                articleForm.Image.ToModel(article.Image);

                _ArticleRepo.Update(article);
                _ArticleRepo.Save();
                ViewBag.Message = "Image updated!";
            }

            if (ModelState.IsValid) {
                var article = _ArticleRepo.GetByID(articleForm.ID);
                _ArticleRepo.Update(articleForm.ToModel(article));
                _ArticleRepo.Save();
                ViewBag.Alert = "Saved!";
                articleForm = ArticleForm.FromModel(article);
            }
            return View("Article", articleForm);
        }

        public IActionResult ArticleDelete(int id) {
            _ArticleRepo.Delete(_ArticleRepo.GetByID(id));
            _ArticleRepo.Save();
            return RedirectToAction("Articles");
        }

        public IActionResult Orders(string query = null) {
            ViewBag.Query = query;
            if (!string.IsNullOrEmpty(query))
                return View(_OrderRepo.GetAll().Where(o => o.Search(query)));
            return View(_OrderRepo.GetAll());
        }

        [HttpGet, Route("{controller}/Order/{id?}")]
        public IActionResult Order(int? id = null) {
            var order = _OrderRepo.GetByID(id);
            return View(order ?? new Order());
        }

        public IActionResult OrderDelete(int id) {
            _OrderRepo.Delete(_OrderRepo.GetByID(id));
            _OrderRepo.Save();
            return RedirectToAction("Orders");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
