using UdemySignalRProject.UI.Dtos;

namespace UdemySignalRProject.UI.IApiServices
{
    public interface IUserApiService
    {
        Task<HttpResponseMessage> UserRegister(string controllerName, RegisterDtos registerDto);
        Task<HttpResponseMessage> UserLogin(string controllerName, LoginDtos loginDtos);
    }
}
