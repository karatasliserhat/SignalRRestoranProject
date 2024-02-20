using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
