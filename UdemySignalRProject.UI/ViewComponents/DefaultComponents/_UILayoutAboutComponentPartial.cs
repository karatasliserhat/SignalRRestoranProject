using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ViewComponents.DefaultComponents
{
    public class _UILayoutAboutComponentPartial : ViewComponent
    {
        private readonly IAboutApiService _aboutApiService;

        public _UILayoutAboutComponentPartial(IAboutApiService aboutApiService)
        {
            _aboutApiService = aboutApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(await _aboutApiService.GetListAsync("About"));
        }
    }
}
