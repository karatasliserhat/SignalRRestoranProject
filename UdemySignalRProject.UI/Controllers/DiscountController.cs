using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.ApiServices;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountApiService _discountApiService;
        private readonly IDataProtector _dataProtector;

        public DiscountController(IDiscountApiService discountApiService, IDataProtectionProvider dataProtectionProvider)
        {
            _discountApiService = discountApiService;
            _dataProtector = dataProtectionProvider.CreateProtector("DiscountController");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _discountApiService.GetListAsync("Discount");
            response.ForEach(x => { x.DataProtect = _dataProtector.Protect(x.DiscountId.ToString()); });

            return View(response);
        }

        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {

            var responseMessage = await _discountApiService.CrateAsync(createDiscountDto, "Discount");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            return View();

        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            var response = await _discountApiService.DeleteAsync(dataUnprodected, "Discount");

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
            var responseData = await _discountApiService.UpdateGetByIdAsync(dataUnprodected, "Discount");
            return View(responseData);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateDiscountDto updateDiscountDto)
        {
            var responseMessage = await _discountApiService.UpdateAsync(updateDiscountDto, "Discount");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            return View();

        }

        public async Task<IActionResult> DiscountChangeStatusTrue(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            var response = await _discountApiService.ChangeStatusTrue("Discount", "DiscountChangeStatusTrue", dataUnprodected);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> DiscountChangeStatusFalse(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            var response = await _discountApiService.ChangeStatusFalse("Discount", "DiscountChangeStatusFalse", dataUnprodected);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
