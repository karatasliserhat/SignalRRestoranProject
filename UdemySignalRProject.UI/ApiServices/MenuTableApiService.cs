using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class MenuTableApiService : GenericApiService<CreateMenuTableDto, UpdateMenuTableDto, ResultMenuTableDto>, IMenuTableApiService
    {
        public MenuTableApiService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
