using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactApiService _contactApiService;
        private readonly IDataProtector _dataProtector;

        public ContactController(IContactApiService contactApiService, IDataProtectionProvider dataProtectionProvider)
        {
            _contactApiService = contactApiService;
            _dataProtector = dataProtectionProvider.CreateProtector("ContactController");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _contactApiService.GetListAsync("Contact");
            response.ForEach(x => { x.DataProtect = _dataProtector.Protect(x.ContactId.ToString()); });

            return View(response);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {

            var responseMessage = await _contactApiService.CrateAsync(createContactDto, "Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            return View();

        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            var response = await _contactApiService.DeleteAsync(dataUnprodected, "Contact");

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
            var responseData = await _contactApiService.UpdateGetByIdAsync(dataUnprodected, "Contact");
            return View(responseData);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactDto  updateContactDto)
        {
            var responseMessage = await _contactApiService.UpdateAsync(updateContactDto, "Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            return View();

        }
    }
}
