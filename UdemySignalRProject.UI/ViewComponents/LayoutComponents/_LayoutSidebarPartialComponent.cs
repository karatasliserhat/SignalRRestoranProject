using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.ViewComponents.LayoutComponents
{
    public class _LayoutSidebarPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
