using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class BasketApiService : GenericApiService<CreateBasketDto, UpdateBasketDto, ResultBasketDto>, IBasketApiService
    {
        private readonly HttpClient _httpClient;
        public BasketApiService(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultBasketDto>> GetBasketByMenuTable(string controller,string action, int id)
        {
            var data = await _httpClient.GetFromJsonAsync<List<ResultBasketDto>>($"{controller}/{action}/{id}");
            return data;
        }
    }
}
