using UdemySignalRProject.UI.Dtos;

namespace UdemySignalRProject.UI.IApiServices
{
    public interface ICategoryApiService:IGenericApiService<CreateCategoryDto,UpdateCategoryDto,ResultCategoryDto>
    {
    }
}
