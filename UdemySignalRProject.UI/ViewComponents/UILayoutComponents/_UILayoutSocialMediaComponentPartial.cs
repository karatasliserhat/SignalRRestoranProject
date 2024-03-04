using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutSocialMediaComponentPartial : ViewComponent
    {
        private readonly ISocialMediaApiService _socialMediaApiService;

        public _UILayoutSocialMediaComponentPartial(ISocialMediaApiService socialMediaApiService)
        {
            _socialMediaApiService = socialMediaApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(await _socialMediaApiService.GetListAsync("SocialMedia"));
        }
    }
}
