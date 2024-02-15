using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class DiscountApiService : GenericApiService<CreateDiscountDto, UpdateDiscountDto, ResultDiscountDto>, IDiscountApiService
    {
        public DiscountApiService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
