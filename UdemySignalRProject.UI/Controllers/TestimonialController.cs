using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.Enums;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialApiService _testimonialApiService;
        private readonly IDataProtector _dataProtector;

        public TestimonialController(ITestimonialApiService testimonialApiService, IDataProtectionProvider dataProtector)
        {
            _testimonialApiService = testimonialApiService;
            _dataProtector = dataProtector.CreateProtector("TestimonialController");
        }


        public void GetTrueFalseSelectList()
        {
            ViewBag.TFList = new SelectList(Enum.GetValues(typeof(TFEnum)));
        }
        public async Task<IActionResult> Index()
        {
            var response = await _testimonialApiService.GetListAsync("Testimonial");
            response.ForEach(x => { x.DataProtect = _dataProtector.Protect(x.TestimonialId.ToString()); });

            return View(response);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            GetTrueFalseSelectList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {

            var responseMessage = await _testimonialApiService.CrateAsync(createTestimonialDto, "Testimonial");
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

            var response = await _testimonialApiService.DeleteAsync(dataUnprodected, "Testimonial");

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
            var responseData = await _testimonialApiService.UpdateGetByIdAsync(dataUnprodected, "Testimonial");
            GetTrueFalseSelectList();
            return View(responseData);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateTestimonialDto updateTestimonialDto)
        {
            var responseMessage = await _testimonialApiService.UpdateAsync(updateTestimonialDto, "Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }
            GetTrueFalseSelectList();
            return View();

        }
    }
}
