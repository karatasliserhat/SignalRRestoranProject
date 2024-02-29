using UdemySignalRProject.DTO.Dtos;

namespace UdemySignalRProject.BusinessLayer.Abstract
{
    public interface IUserService
    {
        Task UserRegister(RegisterDto registerDto);
        Task Login(LoginDto loginDto);
    }
}
