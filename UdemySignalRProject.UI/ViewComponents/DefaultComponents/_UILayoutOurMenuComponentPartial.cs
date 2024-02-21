using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ViewComponents.DefaultComponents
{

    public class _UILayoutOurMenuComponentPartial : ViewComponent
    {
        private readonly IProductApiService _productApiService;

        public _UILayoutOurMenuComponentPartial(IProductApiService productApiService)
        {
            _productApiService = productApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(await _productApiService.GetListAsync("Product"));
        }
    }
}
