using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IUserApiService _userApiService;

        public LoginController(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDtos loginDtos, string returnUrl)
        {
            var response = await _userApiService.UserLogin("Login", loginDtos);
            if (response != null)
            {
                List<Claim> userClaims = new List<Claim>();

                userClaims.Add(new Claim(ClaimTypes.Name, response.UserName));
                userClaims.Add(new Claim(ClaimTypes.GivenName, response.Name));
                userClaims.Add(new Claim(ClaimTypes.Surname, response.Surname));
                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = loginDtos.IsRememberMe
                };

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
    authProperties);

                if (!Url.IsLocalUrl(returnUrl) || returnUrl == "/" || returnUrl == null)
                {
                    return RedirectToAction("Index", "Default");
                }
                return Redirect(returnUrl);
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
