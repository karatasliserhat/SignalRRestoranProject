using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
