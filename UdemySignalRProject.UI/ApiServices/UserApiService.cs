using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class UserApiService : IUserApiService
    {
        private readonly HttpClient _httpClient;

        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> UserRegister(string controllerName, RegisterDtos registerDto)
        {
            var response = await _httpClient.PostAsJsonAsync<RegisterDtos>(controllerName, registerDto);
            return response;
        }
        public async Task<HttpResponseMessage> UserLogin(string controllerName, LoginDtos loginDtos)
        {
            var response = await _httpClient.PostAsJsonAsync<LoginDtos>(controllerName, loginDtos);
            return response;
        }
    }
}
