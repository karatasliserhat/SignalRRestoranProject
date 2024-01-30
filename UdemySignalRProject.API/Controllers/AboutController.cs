using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AboutListAsync()
        {
            var values = await _aboutService.TGetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var data = _mapper.Map<About>(createAboutDto);
            await _aboutService.TAddAsync(data);

            return Ok("Hakkımda Kısmı Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAboutAsync(int id)
        {
            var value = await _aboutService.TGetByIdAsync(id);

            await _aboutService.TDeleteAsync(value);
            return Ok("Hakkımızda alanı silinmiştir");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var data = _mapper.Map<About>(updateAboutDto);
            await _aboutService.TUpdateAsync(data);
            return Ok("Hakkımızda Alanı Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutAsync(int id)
        {
            return Ok(await _aboutService.TGetByIdAsync(id));
        }
    }
}
