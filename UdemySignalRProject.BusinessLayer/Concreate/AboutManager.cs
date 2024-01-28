using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class AboutManager : GenericManager<About>, IAboutService
    {
        public AboutManager(IGenericDal<About> genericDal, IUnitOfWork unitOfWork) : base(genericDal, unitOfWork) { 
        
        
        }


    }
}
