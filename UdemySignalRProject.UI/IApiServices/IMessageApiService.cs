using UdemySignalRProject.UI.Dtos;

namespace UdemySignalRProject.UI.IApiServices
{
    public interface IMessageApiService : IGenericApiService<CreateMessageDto, UpdateMessageDto, ResultMessageDto>
    {
        Task<HttpResponseMessage> ChangeStatusTrue(string controllerName, string actionName, int id);
        Task<HttpResponseMessage> ChangeStatusFalse(string controllerName, string actionName, int id);
        Task<List<ResultMessageDto>> GetListStatusTrue(string controllerName, string actionName);
    }
}
