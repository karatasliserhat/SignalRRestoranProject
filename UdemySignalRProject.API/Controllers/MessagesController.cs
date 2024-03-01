using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        public MessagesController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> MessageList()
        {
            var values = await _messageService.TGetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var data = _mapper.Map<Message>(createMessageDto);
            await _messageService.TAddAsync(data);

            return Ok("Mesaj Başarılı bir şekilde gönderildi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageAsync(int id)
        {
            var value = await _messageService.TGetByIdAsync(id);

            await _messageService.TDeleteAsync(value);
            return Ok("Mesaj silinmiştir");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var data = _mapper.Map<Message>(updateMessageDto);
            await _messageService.TUpdateAsync(data);
            return Ok("Mesaj  Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageAsync(int id)
        {

            return Ok(await _messageService.TGetByIdAsync(id));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> MessageChangeStatusTrue(int id)
        {
            await _messageService.ChangeStautusTrue(id);
            return Ok("Message Okundu");
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> MessageChangeStatusFalse(int id)
        {

            await _messageService.ChangeStautusFalse(id);
            return Ok("Mesaj Okunmadı");
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> MessageListStatusFalse()
        {

            var dataMap = _mapper.Map<List<ResultMessageDto>>(await _messageService.StatusFalseList());
            return Ok(dataMap);
        }
    }
}
