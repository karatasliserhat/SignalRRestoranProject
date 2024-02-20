using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.ViewComponents.DefaultComponents
{
    public class _UILayoutOurMenuComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
