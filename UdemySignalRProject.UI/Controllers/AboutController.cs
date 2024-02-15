using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class AboutController : Controller
    {

        private readonly IAboutApiService _aboutService;
        private readonly IDataProtector _dataProtector;

        public AboutController(IAboutApiService aboutService, IDataProtectionProvider dataProtectionProvider)
        {
            _aboutService = aboutService;
            _dataProtector = dataProtectionProvider.CreateProtector("AboutContoller");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _aboutService.GetListAsync("About");
            response.ForEach(x => { x.DataProtected = _dataProtector.Protect(x.AboutId.ToString()); });

            return View(response);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {

            var responseMessage = await _aboutService.CrateAsync(createAboutDto, "About");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            return View();

        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            var response = await _aboutService.DeleteAsync(dataUnprodected, "About");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));
            var responseData = await _aboutService.UpdateGetByIdAsync(dataUnprodected, "About");
            return View(responseData);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            var responseMessage = await _aboutService.UpdateAsync(updateAboutDto, "About");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            return View();

        }
    }
}
