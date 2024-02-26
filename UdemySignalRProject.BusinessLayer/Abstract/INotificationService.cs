using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        int NotificationCountByStatusfalse();
        List<Notification> GetNotificationStatusFalseList();
        Task NotificationChangeTrue(int id);
        Task NotificationChangefalse(int id);
    }
}
