using UdemySignalRProject.UI.Dtos;

namespace UdemySignalRProject.UI.IApiServices
{
    public interface IUserApiService
    {
        Task<HttpResponseMessage> UserRegister(string controllerName, RegisterDtos registerDto);
        Task<GetUserDto> UserLogin(string controllerName, LoginDtos loginDtos);
        Task<HttpResponseMessage> UserEdit(string controllerName, UserEditDto userEditDto);
        Task<UserEditDto> GetUser(string controllerName, string userName);
    }
}
