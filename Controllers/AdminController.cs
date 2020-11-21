
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

using Debie.Models;
using Debie.Models.DB;
using Debie.Services;
using Debie.Services.Repositories;

namespace Debie.Controllers {
    [Authorize]
    public class AdminController : Controller {
        private readonly ILoginService _LoginService;
        public AdminController(ILoginService loginService) {
            _LoginService = loginService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Login login) {
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
                    return RedirectToAction("Products");
            }
            return View(login);
        }

        public IActionResult Logout() {
            _LoginService.Logout();
            return RedirectToAction("Index", "Page");
        }

        public IActionResult Products() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
