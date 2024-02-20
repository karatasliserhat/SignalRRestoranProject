using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
