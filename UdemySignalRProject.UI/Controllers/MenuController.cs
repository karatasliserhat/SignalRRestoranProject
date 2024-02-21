using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IProductApiService _productApiService;

        public MenuController(IProductApiService productApiService)
        {
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productApiService.GetListAsync("Product"));
        }
    }
}
