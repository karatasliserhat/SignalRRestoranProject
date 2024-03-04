using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
            if (response.IsSuccessStatusCode)
            {
                if (!Url.IsLocalUrl(returnUrl) || returnUrl=="/" || returnUrl==null )
                {
                    return RedirectToAction("Index", "Default");
                }
                return Redirect(returnUrl);
            }
            return View();
        }
    }
}
