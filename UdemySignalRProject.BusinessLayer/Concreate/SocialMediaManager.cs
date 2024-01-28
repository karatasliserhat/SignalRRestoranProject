using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class SocialMediaManager : GenericManager<SocialMedia>, ISocialMediaService
    {
        public SocialMediaManager(IGenericDal<SocialMedia> generiDal, IUnitOfWork unitOfWork) : base(generiDal, unitOfWork)
        {
        }
    }
}
