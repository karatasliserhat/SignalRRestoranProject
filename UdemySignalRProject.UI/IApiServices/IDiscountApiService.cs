using UdemySignalRProject.UI.Dtos;

namespace UdemySignalRProject.UI.IApiServices
{
    public interface IDiscountApiService:IGenericApiService<CreateDiscountDto, UpdateDiscountDto,ResultDiscountDto>
    {
    }
}
