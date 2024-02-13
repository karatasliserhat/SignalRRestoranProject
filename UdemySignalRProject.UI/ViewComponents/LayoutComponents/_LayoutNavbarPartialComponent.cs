using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
