using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class SettingController : Controller
    {
        private readonly IUserApiService _userApiService;

        public SettingController(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = User.Identity.Name;
            var data = await _userApiService.GetUser("Account", user);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if (userEditDto.Password == userEditDto.ConfirmPassword)
            {
                var response = await _userApiService.UserEdit("Account", userEditDto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Şifreler Uyuşmamaktadır");
                return View(await _userApiService.GetUser("Account", User.Identity.Name));
            }

            return View(await _userApiService.GetUser("Account", User.Identity.Name));
        }
    }
}
