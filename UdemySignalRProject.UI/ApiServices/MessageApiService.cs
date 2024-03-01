using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class MessageApiService : GenericApiService<CreateMessageDto, UpdateMessageDto, ResultMessageDto>, IMessageApiService
    {
        private readonly HttpClient _client;
        public MessageApiService(HttpClient httpClient) : base(httpClient)
        {
            _client = httpClient;
        }
        public async Task<HttpResponseMessage> ChangeStatusTrue(string controllerName, string actionName, int id)
        {
            var response = await _client.GetAsync($"{controllerName}/{actionName}/{id}");

            return response;
        }
        public async Task<HttpResponseMessage> ChangeStatusFalse(string controllerName, string actionName, int id)
        {
            var response = await _client.GetAsync($"{controllerName}/{actionName}/{id}");

            return response;
        }
        public async Task<List<ResultMessageDto>> GetListStatusTrue(string controllerName, string actionName)
        {
            var response = await _client.GetFromJsonAsync<List<ResultMessageDto>>($"{controllerName}/{actionName}");

            return response;
        }
    }
}
