using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingApiService _bookingApiService;
        private readonly IDataProtector _dataProtector;

        public BookingController(IBookingApiService bookingApiService, IDataProtectionProvider dataProtectionProvider)
        {
            _bookingApiService = bookingApiService;
            _dataProtector = dataProtectionProvider.CreateProtector("BookingController");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _bookingApiService.GetListAsync("Booking");
            response.ForEach(x => { x.DataProtect = _dataProtector.Protect(x.BookingId.ToString()); });

            return View(response);

        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            var responseMessage = await _bookingApiService.CrateAsync(createBookingDto, "Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            return View();

        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            var response = await _bookingApiService.DeleteAsync(dataUnprodected, "Booking");

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
            var responseData = await _bookingApiService.UpdateGetByIdAsync(dataUnprodected, "Booking");
            return View(responseData);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBookingDto updateBookingDto)
        {
            var responseMessage = await _bookingApiService.UpdateAsync(updateBookingDto, "Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }

            return View();

        }
    }
}
