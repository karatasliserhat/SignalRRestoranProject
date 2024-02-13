using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.ViewComponents.LayoutComponents
{
    public class _LayoutFeaturePartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
