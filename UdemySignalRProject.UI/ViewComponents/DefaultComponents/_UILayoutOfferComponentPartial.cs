using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ViewComponents.DefaultComponents
{

    public class _UILayoutOfferComponentPartial : ViewComponent
    {
        private readonly IDiscountApiService _discountApiService;
        public _UILayoutOfferComponentPartial(IDiscountApiService discountApiService)
        {
            _discountApiService = discountApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {


            return View(await _discountApiService.GetListStatusTrue("Discount", "DiscountListStatusTrue"));
        }
    }
}
