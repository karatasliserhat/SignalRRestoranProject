using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user != null)
            {
               await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.IsRememberMe, true);
      
            }
        }

        public async Task UserRegister(RegisterDto registerDto)
        {

            var userData = await _userManager.FindByEmailAsync(registerDto.Email);
            if (userData is null)
            {
                var appUser = _mapper.Map<AppUser>(registerDto);
                await _userManager.CreateAsync(appUser, registerDto.Password);
            }
        }

    }
}
