using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    [AllowAnonymous]

    public class DefaultController : Controller
    {
        private readonly IMessageApiService _messageApiService;

        public DefaultController(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            var response = await _messageApiService.CrateAsync(createMessageDto, "Messages");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createMessageDto);
        }
    }
}
