
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Linq;

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

        public AdminController(ILoginService loginService, IArticleRepository articleRepo, IOrderRepository orderRepo, IProductRepository productRepo) {
            _LoginService = loginService;
            _ArticleRepo = articleRepo;
            _OrderRepo = orderRepo;
            _ProductRepo = productRepo;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl = "") {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index");

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
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

        public IActionResult ProductEdit(int? id = null) {
            var product = _ProductRepo.GetByID(id);
            return View(product ?? new Product());
        }

        public IActionResult Articles(string query = null) {
            ViewBag.Query = query;
            if (!string.IsNullOrEmpty(query))
                return View(_ArticleRepo.GetAll().Where(a => a.Search(query)));
            return View(_ArticleRepo.GetAll());
        }

        public IActionResult ArticleEdit(int? id = null) {
            var article = _ArticleRepo.GetByID(id);
            return View(article ?? new Article());
        }

        public IActionResult Orders(string query = null) {
            ViewBag.Query = query;
            if (!string.IsNullOrEmpty(query))
                return View(_OrderRepo.GetAll().Where(o => o.Search(query)));
            return View(_OrderRepo.GetAll());
        }

        public IActionResult OrderEdit(int? id = null) {
            var order = _OrderRepo.GetByID(id);
            return View(order ?? new Order());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
