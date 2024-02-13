using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
