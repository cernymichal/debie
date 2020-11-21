using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

using Debie.Models;
using Debie.Models.DB;
using Debie.Services.Repositories;

namespace Debie.Services {
    public interface ILoginService {
        User GetCurrentUser();
        void Login(Login login);
        void Logout();
        byte[] PasswordHash(string password);
    }

    public class LoginService : ILoginService {
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly IUserRepository _UserRepo;
        public LoginService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepo) {
            _HttpContextAccessor = httpContextAccessor;
            _UserRepo = userRepo;
        }

        public User GetCurrentUser() {
            var id = _HttpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return _UserRepo.GetByID(Convert.ToInt32(id));
        }

        public void Login(Login login) {
            var passwordHash = PasswordHash(login.Password);
            var user = _UserRepo.GetAll().SingleOrDefault(u => u.Username == login.Username && u.Password.SequenceEqual(passwordHash));

            if (user != null) {
                CreateCookie(user, login.RememberMe);
            }
            else
                throw new CryptographicException();
        }

        public async void Logout() {
            await _HttpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private async void CreateCookie(User user, bool persistent) {
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim("Created", DateTime.UtcNow.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties {
                AllowRefresh = true,
                IsPersistent = persistent,
                IssuedUtc = DateTimeOffset.UtcNow
            };

            await _HttpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public byte[] PasswordHash(string password) {
            byte[] bytes;
            using (var sha = SHA256.Create()) {
                bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            return bytes;
        }
    }
}
