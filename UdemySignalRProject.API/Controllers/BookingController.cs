using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IDataProtector _dataProtector;

        public BookingController(IBookingService bookingService, IMapper mapper, IDataProtectionProvider dataProtector)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _dataProtector = dataProtector.CreateProtector("BookingApiController");
        }
        [HttpGet]
        public async Task<IActionResult> BookingList()
        {
            var values = await _bookingService.TGetAllAsync();
            var mapDatas = _mapper.Map<List<ResultBookingDto>>(values);
            mapDatas.ForEach(x => x.DataProtect = _dataProtector.Protect(x.BookingId.ToString()));
            return Ok(mapDatas);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            var data = _mapper.Map<Booking>(createBookingDto);
            await _bookingService.TAddAsync(data);

            return Ok("Rezervasyon  Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingAsync(string id)
        {
            var valueId = int.Parse(_dataProtector.Unprotect(id));
            var value = await _bookingService.TGetByIdAsync(valueId);

            await _bookingService.TDeleteAsync(value);
            return Ok("Rezervasyon  silinmiştir");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBookingAsync(UpdateBookingDto updateBookingDto)
        {
            var data = _mapper.Map<Booking>(updateBookingDto);
            await _bookingService.TUpdateAsync(data);
            return Ok("Rezervasyon  Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingAsync(string id)
        {
            var valueId = int.Parse(_dataProtector.Unprotect(id));
            return Ok(await _bookingService.TGetByIdAsync(valueId));
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> BookingStatusApproved(string id)
        {
            var valueId = int.Parse(_dataProtector.Unprotect(id));
            await _bookingService.BookingStatusApproved(valueId);
            return Ok("Rezervasyon Onaylandı");
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> BookingStatusCancelled(string id)
        {
            var valueId = int.Parse(_dataProtector.Unprotect(id));
            await _bookingService.BokingStatusCancelled(valueId);
            return Ok("Rezervasyon İptal Edildi");
        }
    }

}
