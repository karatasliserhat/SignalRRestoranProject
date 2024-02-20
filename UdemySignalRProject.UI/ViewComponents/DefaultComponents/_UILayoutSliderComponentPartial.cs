using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.ViewComponents.DefaultComponents
{
    public class _UILayoutSliderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
