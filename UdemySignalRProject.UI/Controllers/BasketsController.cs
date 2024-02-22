using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class BasketsController : Controller
    {
        private readonly IBasketApiService _basketApiService;

        public BasketsController(IBasketApiService basketApiService)
        {
            _basketApiService = basketApiService;
        }

        public async Task<IActionResult> Index(int id)
        {

            return View(await _basketApiService.GetBasketByMenuTable("Baskets", "GetBasketByMasaTable", 8));
        }
        public async Task<IActionResult> BasketDelete(int id)
        {
            var result = await _basketApiService.DeleteAsync(id, "Baskets");
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
