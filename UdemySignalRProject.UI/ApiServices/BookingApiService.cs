using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class BookingApiService : GenericApiService<CreateBookingDto, UpdateBookingDto, ResultBookingDto>, IBookingApiService
    {
        private readonly HttpClient _client;
        public BookingApiService(HttpClient httpClient) : base(httpClient)
        {
            _client = httpClient;
        }

        public async Task<HttpResponseMessage> BookingStatusApproved(string controllerName, string actionName, string id)
        {
            var response = await _client.GetAsync($"{controllerName}/{actionName}/{id}");

            return response;
        }
        public async Task<HttpResponseMessage> BookingStatusCancelled(string controllerName, string actionName, string id)
        {
            var response = await _client.GetAsync($"{controllerName}/{actionName}/{id}");

            return response;
        }
    }
}
