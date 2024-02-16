using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaApiService _socialMediaApiService;
        private readonly IDataProtector _dataProtector;

        public SocialMediaController(ISocialMediaApiService socialMediaApiService, IDataProtectionProvider dataProtectionProvider)
        {
            _socialMediaApiService = socialMediaApiService;
            _dataProtector = dataProtectionProvider.CreateProtector("SocialMediaController");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _socialMediaApiService.GetListAsync("SocialMedia");
            response.ForEach(x => { x.DataProtect = _dataProtector.Protect(x.SocialMediaId.ToString()); });

            return View(response);

        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {

            var responseMessage = await _socialMediaApiService.CrateAsync(createSocialMediaDto, "SocialMedia");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }
            return View();

        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            var response = await _socialMediaApiService.DeleteAsync(dataUnprodected, "SocialMedia");

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
            var responseData = await _socialMediaApiService.UpdateGetByIdAsync(dataUnprodected, "SocialMedia");
            return View(responseData);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var responseMessage = await _socialMediaApiService.UpdateAsync(updateSocialMediaDto, "SocialMedia");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            return View();

        }
    }
}
