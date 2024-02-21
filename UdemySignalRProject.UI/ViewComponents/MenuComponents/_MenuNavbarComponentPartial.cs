using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.ViewComponents.MenuComponents
{
    public class _MenuNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
