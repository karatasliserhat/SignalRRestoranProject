using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.ViewComponents.DefaultComponents
{
    public class _UILayoutOfferComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
