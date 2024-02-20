using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
