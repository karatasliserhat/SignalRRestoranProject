using AutoMapper;
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

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> BookingList()
        {
            var values = await _bookingService.TGetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            var data = _mapper.Map<Booking>(createBookingDto);
            await _bookingService.TAddAsync(data);

            return Ok("Rezervasyon  Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingAsync(int id)
        {
            var value = await _bookingService.TGetByIdAsync(id);

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
        public async Task<IActionResult> GetBookingAsync(int id)
        {
            
            return Ok(await _bookingService.TGetByIdAsync(id));
        }
    }

}
