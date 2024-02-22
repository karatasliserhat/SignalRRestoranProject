using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IProductApiService _productApiService;
        private readonly IBasketApiService _basketApiService;
        public MenuController(IProductApiService productApiService, IBasketApiService basketApiService)
        {
            _productApiService = productApiService;
            _basketApiService = basketApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productApiService.GetListAsync("Product"));
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id)
        {
            CreateBasketDto createBasketDto = new CreateBasketDto();
            createBasketDto.ProductId = id;
                var response = await _basketApiService.CrateAsync(createBasketDto, "Baskets");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return Json(createBasketDto);
        }
    }
}
