using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        private readonly IContactApiService _contactApiService;

        public _UILayoutFooterComponentPartial(IContactApiService contactApiService)
        {
            _contactApiService = contactApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _contactApiService.GetListAsync("Contact"));
        }
    }
}
