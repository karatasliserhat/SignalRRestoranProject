using UdemySignalRProject.UI.Dtos;

namespace UdemySignalRProject.UI.IApiServices
{
    public interface IBasketApiService:IGenericApiService<CreateBasketDto,UpdateBasketDto,ResultBasketDto>
    {
        Task<List<ResultBasketDto>> GetBasketByMenuTable(string controller, string action, int id);
    }
}
