using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class FeatureController : Controller
    {

        private readonly IFeatureApiService _featureApiService;
        private readonly IDataProtector _dataProtector;

        public FeatureController(IFeatureApiService featureApiService, IDataProtectionProvider dataProtectionProvider)
        {
            _featureApiService = featureApiService;
            _dataProtector = dataProtectionProvider.CreateProtector("FeatureController");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _featureApiService.GetListAsync("Feature");
            response.ForEach(x => { x.DataProtect = _dataProtector.Protect(x.FeatureId.ToString()); });

            return View(response);
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {

            var responseMessage = await _featureApiService.CrateAsync(createFeatureDto, "Feature");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            return View();

        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            var response = await _featureApiService.DeleteAsync(dataUnprodected, "Feature");

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
            var responseData = await _featureApiService.UpdateGetByIdAsync(dataUnprodected, "Feature");
            return View(responseData);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
        {
            var responseMessage = await _featureApiService.UpdateAsync(updateFeatureDto, "Feature");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            return View();

        }
    }
}
