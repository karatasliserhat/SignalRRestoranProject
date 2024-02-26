using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class NotificationApiService : GenericApiService<CreateNotificationDto, UpdateNotificationDto, ResultNotificationDto>, INotificationApiService
    {
        private readonly HttpClient _httpClient;
        public NotificationApiService(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task NotificationChangeFalse(string controllerName, string actionName, int id)
        {
            var response = await _httpClient.GetAsync($"{controllerName}/{actionName}/{id}");
        }

        public async Task NotificationChangeTrue(string controllerName, string actionName, int id)
        {
            var response = await _httpClient.GetAsync($"{controllerName}/{actionName}/{id}");
        }
    }
}
