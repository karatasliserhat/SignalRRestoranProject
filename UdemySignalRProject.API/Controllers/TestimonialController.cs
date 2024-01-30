using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            return Ok(await _testimonialService.TGetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> TestimonialCreate(CreateTestimonialDto createTestimonialDto)
        {
            var data = _mapper.Map<Testimonial>(createTestimonialDto);
            await _testimonialService.TAddAsync(data);
            return Ok("Referans Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            return Ok(await _testimonialService.TGetByIdAsync(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var data = await _testimonialService.TGetByIdAsync(id);
            await _testimonialService.TDeleteAsync(data);

            return Ok("Referans silindi");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateTestimonialDto  updateTestimonialDto)
        {
            var data = _mapper.Map<Testimonial>(updateTestimonialDto);
            await _testimonialService.TUpdateAsync(data);

            return Ok("Referans Güncellendi");
        }
    }
}
