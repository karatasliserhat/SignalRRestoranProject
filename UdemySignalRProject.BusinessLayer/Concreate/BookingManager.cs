using Microsoft.EntityFrameworkCore;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class BookingManager : GenericManager<Booking>, IBookingService
    {
        private readonly SignalRContext _context;
        public BookingManager(IGenericDal<Booking> generiDal, IUnitOfWork unitOfWork, SignalRContext context) : base(generiDal, unitOfWork)
        {
            _context = context;
        }

        public async Task BokingStatusCancelled(int id)
        {
            await _context.Bookings.Where(x => x.BookingId == id).ExecuteUpdateAsync(x => x.SetProperty(y => y.Description, "Rezervasyon İptal Edildi"));
        }

        public async Task BookingStatusApproved(int id)
        {
            await _context.Bookings.Where(x => x.BookingId == id).ExecuteUpdateAsync(x => x.SetProperty(y => y.Description, "Rezervasyon Alındı"));
        }
    }
}
