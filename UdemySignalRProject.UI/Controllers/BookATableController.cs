using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IBookingApiService _bookingApiService;

        public BookATableController(IBookingApiService bookingApiService)
        {
            _bookingApiService = bookingApiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            var response = await _bookingApiService.CrateAsync(createBookingDto, "Booking");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(createBookingDto);
        }
    }
}
