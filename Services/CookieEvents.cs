using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

using Debie.Services.Repositories;

public class CookieEvents : CookieAuthenticationEvents {
    private readonly IUserRepository _UserRepo;

    public CookieEvents(IUserRepository userRepo) {
        _UserRepo = userRepo;
    }

    public override async Task ValidatePrincipal(CookieValidatePrincipalContext context) {
        var lastChanged = context.Principal.Claims.First(c => c.Type == "LastChanged").Value;
        var id = Convert.ToInt32(
            context.Principal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value
        );

        var user = _UserRepo.GetByID(id);

        if (string.IsNullOrEmpty(lastChanged) || user != null || user.LastChanged < DateTime.Parse(lastChanged)) {
            context.RejectPrincipal();

            await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}