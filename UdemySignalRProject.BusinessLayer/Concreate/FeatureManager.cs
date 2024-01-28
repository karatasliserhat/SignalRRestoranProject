using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class FeatureManager : GenericManager<Feature>, IFeatureService
    {
        public FeatureManager(IGenericDal<Feature> generiDal, IUnitOfWork unitOfWork) : base(generiDal, unitOfWork)
        {
        }
    }
}
