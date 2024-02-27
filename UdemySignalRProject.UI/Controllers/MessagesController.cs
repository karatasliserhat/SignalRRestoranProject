using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClientUserCount()
        {
            return View();
        }
    }
}
