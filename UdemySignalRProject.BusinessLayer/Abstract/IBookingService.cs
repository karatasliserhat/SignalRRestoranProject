using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        Task BookingStatusApproved(int id);
        Task BokingStatusCancelled(int id);
    }
}
