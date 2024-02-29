using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            await _userService.UserRegister(registerDto);

            return Ok("User Oluşturuldu");
        }
    }
}
