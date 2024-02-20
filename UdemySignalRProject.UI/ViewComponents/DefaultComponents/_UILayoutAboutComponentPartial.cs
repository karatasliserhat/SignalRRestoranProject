using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.ViewComponents.DefaultComponents
{
    public class _UILayoutAboutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
