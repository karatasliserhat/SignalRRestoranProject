using Newtonsoft.Json;
using System.Text;
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
        public async Task<GetUserDto> UserLogin(string controllerName, LoginDtos loginDtos)
        {
            var jsonData = JsonConvert.SerializeObject(loginDtos);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(controllerName, stringContent);

            return JsonConvert.DeserializeObject<GetUserDto>(await response.Content.ReadAsStringAsync());
        }

        public async Task<HttpResponseMessage> UserEdit(string controllerName, UserEditDto userEditDto)
        {
            var response = await _httpClient.PutAsJsonAsync<UserEditDto>(controllerName, userEditDto);
            return response;
        }
        public async Task<UserEditDto> GetUser(string controllerName, string userName)
        {
            var response = await _httpClient.GetFromJsonAsync<UserEditDto>($"{controllerName}/{userName}");
            return response;
        }
    }
}
