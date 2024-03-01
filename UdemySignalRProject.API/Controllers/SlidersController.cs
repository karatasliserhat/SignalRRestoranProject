using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        public SlidersController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSlider()
        {
            var datas = await _sliderService.TGetAllAsync();

            return Ok(_mapper.Map<List<ResultSlidereDto>>(datas));
        }
        [HttpPost]
        public async Task<IActionResult> SliderCreate(CreateSliderDto createSliderDto)
        {
            var data = _mapper.Map<Slider>(createSliderDto);
            await _sliderService.TAddAsync(data);
            return Ok("Öne Çıkan Alan Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            return Ok(await _sliderService.TGetByIdAsync(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var data = await _sliderService.TGetByIdAsync(id);
            await _sliderService.TDeleteAsync(data);

            return Ok("Öne Çıkan alan silindi");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateSliderDto updateSliderDto)
        {
            var data = _mapper.Map<Slider>(updateSliderDto);
            await _sliderService.TUpdateAsync(data);

            return Ok("Öne Çıkan alan Güncellendi");
        }
    }
}
