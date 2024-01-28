using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class BookingManager : GenericManager<Booking>, IBookingService
    {
        public BookingManager(IGenericDal<Booking> generiDal, IUnitOfWork unitOfWork) : base(generiDal, unitOfWork)
        {
        }
    }
}
