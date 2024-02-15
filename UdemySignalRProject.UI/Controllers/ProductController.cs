using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemySignalRProject.UI.Enums;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiService _productService;
        private readonly IDataProtector _dataProtector;
        private readonly ICategoryApiService _categoryApiService;
        public ProductController(IProductApiService productService, IDataProtectionProvider dataProtector, ICategoryApiService categoryApiService)
        {
            _productService = productService;
            _dataProtector = dataProtector.CreateProtector("ProductController");
            _categoryApiService = categoryApiService;
        }

        public async Task GetCategorySelectList(int id = 0)
        {
            var responseCategory = await _categoryApiService.GetListAsync("Category");
            ViewBag.CategoryData = new SelectList(responseCategory, "CategoryId", "CategoryName", id);

        }
        public void GetTrueFalseSelectList()
        {
            ViewBag.TFList = new SelectList(Enum.GetValues(typeof(TFEnum)));
        }
        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetListAsync("Product/GetProductWithCategories");
            response.ForEach(x => { x.DataProtect = _dataProtector.Protect(x.ProductId.ToString()); });

            return View(response);

        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            await GetCategorySelectList();
            GetTrueFalseSelectList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {

            var responseMessage = await _productService.CrateAsync(createProductDto, "Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }
            await GetCategorySelectList();
            GetTrueFalseSelectList();
            return View();

        }
        public async Task<IActionResult> Delete(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            var response = await _productService.DeleteAsync(dataUnprodected, "Product");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));
            var responseData = await _productService.UpdateGetByIdAsync(dataUnprodected, "Product");
            await GetCategorySelectList(responseData.CategoryId);
            GetTrueFalseSelectList();
            return View(responseData);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var responseMessage = await _productService.UpdateAsync(updateProductDto, "Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            await GetCategorySelectList(updateProductDto.CategoryId);

            return View();

        }
    }
}
