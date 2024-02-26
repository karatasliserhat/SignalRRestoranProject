using UdemySignalRProject.UI.Dtos;

namespace UdemySignalRProject.UI.IApiServices
{
    public interface INotificationApiService : IGenericApiService<CreateNotificationDto, UpdateNotificationDto, ResultNotificationDto>
    {
        Task NotificationChangeTrue(string controllerName, string actionName,int id);
        Task NotificationChangeFalse(string controllerName, string actionName, int id);
    }
}
