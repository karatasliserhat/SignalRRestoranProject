using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
      
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _contactService.TGetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContactAsync(CreateContactDto createContactDto)
        {
            var data = _mapper.Map<Contact>(createContactDto);
            await _contactService.TAddAsync(data);

            return Ok("İletişim  Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactAsync(int id)
        {
            var value = await _contactService.TGetByIdAsync(id);

            await _contactService.TDeleteAsync(value);
            return Ok("İletişim  silinmiştir");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var data = _mapper.Map<Contact>(updateContactDto);
            await _contactService.TUpdateAsync(data);
            return Ok("İletişim  Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactAsync(int id)
        {

            return Ok(await _contactService.TGetByIdAsync(id));
        }
    }
}
