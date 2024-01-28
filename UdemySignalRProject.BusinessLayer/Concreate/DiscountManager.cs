using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class DiscountManager : GenericManager<Discount>, IDiscountService
    {
        public DiscountManager(IGenericDal<Discount> generiDal, IUnitOfWork unitOfWork) : base(generiDal, unitOfWork)
        {
        }
    }
}
