using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class SliderController : Controller
    {

        private readonly ISliderApiService _sliderApiService;
        private readonly IDataProtector _dataProtector;

        public SliderController(ISliderApiService sliderApiService, IDataProtectionProvider dataProtectionProvider)
        {
            _sliderApiService = sliderApiService;
            _dataProtector = dataProtectionProvider.CreateProtector("SliderController");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _sliderApiService.GetListAsync("Sliders");
            response.ForEach(x => { x.DataProtector = _dataProtector.Protect(x.SliderId.ToString()); });

            return View(response);
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {

            var responseMessage = await _sliderApiService.CrateAsync(createSliderDto, "Sliders");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            return View();

        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            var response = await _sliderApiService.DeleteAsync(dataUnprodected, "Sliders");

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
            var responseData = await _sliderApiService.UpdateGetByIdAsync(dataUnprodected, "Sliders");
            return View(responseData);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSliderDto updateSliderDto)
        {
            var responseMessage = await _sliderApiService.UpdateAsync(updateSliderDto, "Sliders");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            return View();

        }
    }
}
