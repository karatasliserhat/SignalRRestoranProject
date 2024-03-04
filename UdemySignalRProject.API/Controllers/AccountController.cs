using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;

namespace UdemySignalRProject.API.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPut]
        public async Task<IActionResult> UserEdit(UserEditDto userEditDto)
        {
            await _userService.UserEdit(userEditDto);
            return Ok("User Güncellendi");
        }
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUser(string userName)
        {
            var data=await _userService.GetUser(userName);
            return Ok(data);
        }
    }
}
