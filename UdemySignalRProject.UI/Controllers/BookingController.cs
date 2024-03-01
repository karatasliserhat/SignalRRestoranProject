using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingApiService _bookingApiService;

        public BookingController(IBookingApiService bookingApiService)
        {
            _bookingApiService = bookingApiService;
        }

        public IActionResult Index()
        {
            //var response = await _bookingApiService.GetListAsync("Booking");

            return View();

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

            var response = await _bookingApiService.DeleteAsync(id, "Booking");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var responseData = await _bookingApiService.UpdateGetByIdAsync(id, "Booking");
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
        public async Task<IActionResult> BookingStatusApproved(string id)
        {

            var response = await _bookingApiService.BookingStatusApproved("Booking", "BookingStatusApproved", id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> BookingStatusCancelled(string id)
        {

            var response = await _bookingApiService.BookingStatusCancelled("Booking", "BookingStatusCancelled", id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}
