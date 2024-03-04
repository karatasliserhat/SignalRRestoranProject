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

        public async Task<GetUserDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.IsRememberMe, true);
            var dataMap = _mapper.Map<GetUserDto>(user);
            return dataMap;

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

        public async Task UserEdit(UserEditDto userEditDto)
        {
            var userEdit = await _userManager.FindByNameAsync(userEditDto.UserName);
            if (userEdit is not null)
            {
                userEdit.Surname = userEditDto.Surname;
                userEdit.Name = userEditDto.Name;
                userEdit.Email = userEditDto.Email;
                if (userEditDto.Password is not null)
                    _userManager.PasswordHasher.HashPassword(userEdit, userEditDto.Password);
                var response = await _userManager.UpdateAsync(userEdit);
                if (response.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(userEdit);


                }
            }
        }
        public async Task<UserEditDto> GetUser(string userName)
        {
            var userData = await _userManager.FindByNameAsync(userName);

            var values = _mapper.Map<UserEditDto>(userData);

            return values;
        }
    }
}
