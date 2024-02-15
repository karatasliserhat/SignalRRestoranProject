using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class ProductApiService : GenericApiService<CreateProductDto, UpdateProductDto, ResultProductDto>, IProductApiService
    {
        public ProductApiService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
