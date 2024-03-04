using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.Enums;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryApiService _categoryApiService;
        private readonly IDataProtector _dataProtector;

        public CategoryController(ICategoryApiService categoryApiService, IDataProtectionProvider dataProtection)
        {
            _dataProtector = dataProtection.CreateProtector("CategoryController");
            _categoryApiService = categoryApiService;
        }
        public void GetTrueFalseSelectList()
        {
            ViewBag.TFList = new SelectList(Enum.GetValues(typeof(TFEnum)));
        }
        public async Task<IActionResult> Index()
        {
            var response = await _categoryApiService.GetListAsync("Category");
            response.ForEach(x => { x.DataProtector = _dataProtector.Protect(x.CategoryId.ToString()); });

            return View(response);

        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            GetTrueFalseSelectList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {

            var responseMessage = await _categoryApiService.CrateAsync(createCategoryDto, "Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            GetTrueFalseSelectList();
            return View();

        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            var response = await _categoryApiService.DeleteAsync(dataUnprodected, "Category");

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
            var responseData = await _categoryApiService.UpdateGetByIdAsync(dataUnprodected, "Category");
            GetTrueFalseSelectList();
            return View(responseData);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var responseMessage = await _categoryApiService.UpdateAsync(updateCategoryDto, "Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }
            GetTrueFalseSelectList();

            return View();

        }

    }
}
