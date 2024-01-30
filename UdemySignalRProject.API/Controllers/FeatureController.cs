using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            return Ok(await _featureService.TGetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> FeatureCreate(CreateFeatureDto createFeatureDto)
        {
            var data = _mapper.Map<Feature>(createFeatureDto);
            await _featureService.TAddAsync(data);
            return Ok("Özellik Alanı Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            return Ok(await _featureService.TGetByIdAsync(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var data = await _featureService.TGetByIdAsync(id);
            await _featureService.TDeleteAsync(data);

            return Ok("Özellik alanı silindi");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var data = _mapper.Map<Feature>(updateFeatureDto);
            await _featureService.TUpdateAsync(data);

            return Ok("Ürün Güncellendi");
        }
    }
}
