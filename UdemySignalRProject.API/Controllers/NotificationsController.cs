using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public NotificationsController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> NotificationList()
        {
            var values = await _notificationService.TGetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotificationAsync(CreateNotificationDto createNotificationDto)
        {
            var data = _mapper.Map<Notification>(createNotificationDto);
            await _notificationService.TAddAsync(data);

            return Ok("Bildirim Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificationAsync(int id)
        {
            var value = await _notificationService.TGetByIdAsync(id);

            await _notificationService.TDeleteAsync(value);
            return Ok("Bildirim silinmiştir");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateNotificationAsync(UpdateNotificationDto updateNotificationDto)
        {
            var data = _mapper.Map<Notification>(updateNotificationDto);
            await _notificationService.TUpdateAsync(data);
            return Ok("Bildirim  Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationAsync(int id)
        {

            return Ok(await _notificationService.TGetByIdAsync(id));
        }
        [HttpGet("NotificationChangeTrue/{id}")]
        public async Task<IActionResult> NotificationChangeTrue(int id)
        {
            await _notificationService.NotificationChangeTrue(id);
            return Ok("Bildirim Okundu");
        }
        [HttpGet("NotificationChangefalse/{id}")]
        public async Task<IActionResult> NotificationChangefalse(int id)
        {
            await _notificationService.NotificationChangefalse(id);
            return Ok("bildirim okunmadı");
        }
        [HttpGet("GetNotificationCountByStatusfalse")]
        public IActionResult GetNotificationCountByStatusfalse()
        {

            return Ok(_notificationService.NotificationCountByStatusfalse());
        }
        [HttpGet("GetNotificationStatusFalseList")]
        public IActionResult GetNotificationStatusFalseList()
        {

            return Ok(_notificationService.GetNotificationStatusFalseList());
        }
    }
}
