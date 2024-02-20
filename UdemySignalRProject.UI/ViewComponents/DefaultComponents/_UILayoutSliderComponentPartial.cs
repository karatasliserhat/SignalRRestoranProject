using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ViewComponents.DefaultComponents
{
    public class _UILayoutSliderComponentPartial : ViewComponent
    {
        private readonly ISliderApiService _sliderApiService;

        public _UILayoutSliderComponentPartial(ISliderApiService sliderApiService)
        {
            _sliderApiService = sliderApiService;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            return View(await _sliderApiService.GetListAsync("Sliders"));
        }
    }
}
