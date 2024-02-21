using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ViewComponents.DefaultComponents
{
    public class _UILayoutTestimonialComponentPartial : ViewComponent
    {
        private readonly ITestimonialApiService _testimonialApiService;

        public _UILayoutTestimonialComponentPartial(ITestimonialApiService testimonialApiService)
        {
            _testimonialApiService = testimonialApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _testimonialApiService.GetListAsync("Testimonial"));
        }
    }
}
