using UdemySignalRProject.DTO.Dtos;

namespace UdemySignalRProject.BusinessLayer.Abstract
{
    public interface IUserService
    {
        Task UserRegister(RegisterDto registerDto);
        Task<GetUserDto> Login(LoginDto loginDto);
        Task UserEdit(UserEditDto userEditDto);
        Task<UserEditDto> GetUser(string userName);
    }
}
