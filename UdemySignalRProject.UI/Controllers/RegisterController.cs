using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserApiService _userApiService;

        public RegisterController(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDtos registerDtos)
        {
            var response = await _userApiService.UserRegister("Register", registerDtos);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
