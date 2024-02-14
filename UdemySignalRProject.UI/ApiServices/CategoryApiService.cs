using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class CategoryApiService : GenericApiService<CreateCategoryDto, UpdateCategoryDto, ResultCategoryDto>,ICategoryApiService
    {
        public CategoryApiService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
