using UdemySignalRProject.UI.Dtos;

namespace UdemySignalRProject.UI.IApiServices
{
    public interface IDiscountApiService:IGenericApiService<CreateDiscountDto, UpdateDiscountDto,ResultDiscountDto>
    {
        Task<HttpResponseMessage> ChangeStatusTrue(string controllerName, string actionName, int id);
        Task<HttpResponseMessage> ChangeStatusFalse(string controllerName, string actionName, int id);
        Task<List<ResultDiscountDto>> GetListStatusTrue(string controllerName, string actionName);
    }
}
