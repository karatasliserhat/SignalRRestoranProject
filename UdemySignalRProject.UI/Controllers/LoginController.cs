using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
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
        public async Task<IActionResult> Index(LoginDtos loginDtos)
        {
            var response = await _userApiService.UserLogin("Login", loginDtos);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
