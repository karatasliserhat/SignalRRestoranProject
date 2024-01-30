using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            return Ok(await _socialMediaService.TGetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> SocialMediaCreate(CreateSocialMediaDto socialMediaDto)
        {
            var data = _mapper.Map<SocialMedia>(socialMediaDto);
            await _socialMediaService.TAddAsync(data);
            return Ok("Sosyal Medya Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            return Ok(await _socialMediaService.TGetByIdAsync(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var data = await _socialMediaService.TGetByIdAsync(id);
            await _socialMediaService.TDeleteAsync(data);

            return Ok("Sosyal Medya silindi");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var data = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            await _socialMediaService.TUpdateAsync(data);

            return Ok("Sosyal Medya Güncellendi");
        }
    }
}
