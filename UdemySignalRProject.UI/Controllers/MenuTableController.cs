using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.Enums;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class MenuTableController : Controller
    {
        private readonly IMenuTableApiService _menuTableApiService;
        private readonly IDataProtector _dataProtector;

        public MenuTableController(IDataProtectionProvider dataProtector, IMenuTableApiService menuTableApiService)
        {
            _dataProtector = dataProtector.CreateProtector("MenuTableController");
            _menuTableApiService = menuTableApiService;
        }
        public void GetTrueFalseSelectList()
        {
            ViewBag.TFList = new SelectList(Enum.GetValues(typeof(TFEnum)));
        }
        public async Task<IActionResult> Index()
        {
            var response = await _menuTableApiService.GetListAsync("MenuTables");
            response.ForEach(x => { x.DataProtector = _dataProtector.Protect(x.MenuTableId.ToString()); });

            return View(response);
        }

        [HttpGet]
        public IActionResult CreateMenuTable()
        {
            GetTrueFalseSelectList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {

            var responseMessage = await _menuTableApiService.CrateAsync(createMenuTableDto, "MenuTables");
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

            var response = await _menuTableApiService.DeleteAsync(dataUnprodected, "MenuTables");

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
            var responseData = await _menuTableApiService.UpdateGetByIdAsync(dataUnprodected, "MenuTables");
            GetTrueFalseSelectList();
            return View(responseData);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateMenuTableDto updateMenuTableDto)
        {
            var responseMessage = await _menuTableApiService.UpdateAsync(updateMenuTableDto, "MenuTables");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }
            GetTrueFalseSelectList();
            return View();

        }

        public async Task<IActionResult> MenuTableListByStatus()
        {
            var datas = await _menuTableApiService.GetListAsync("MenuTables");
            return View(datas);
        }
    }
}
