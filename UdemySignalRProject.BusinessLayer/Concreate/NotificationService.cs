using Microsoft.EntityFrameworkCore;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class NotificationService : GenericManager<Notification>, INotificationService
    {
        private readonly SignalRContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public NotificationService(IGenericDal<Notification> generiDal, IUnitOfWork unitOfWork, SignalRContext context) : base(generiDal, unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public List<Notification> GetNotificationStatusFalseList()
        {
            return _context.Notifications.Where(x => x.Status == false).ToList();
        }

        public async Task NotificationChangefalse(int id)
        {
            await _context.Notifications.Where(x=> x.NotificationId==id).ExecuteUpdateAsync(x => x.SetProperty(y => y.Status, false));

        }

        public async Task NotificationChangeTrue(int id)
        {
            await _context.Notifications.Where(x => x.NotificationId == id).ExecuteUpdateAsync(x => x.SetProperty(y => y.Status, true));
        }

        public int NotificationCountByStatusfalse()
        {
            return _context.Notifications.Count(x => x.Status == false);
        }
    }
}
