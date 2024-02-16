using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{

    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly SignalRContext _signalrContext;
        public CategoryManager(IGenericDal<Category> generiDal, IUnitOfWork unitOfWork, SignalRContext signalrContext) : base(generiDal, unitOfWork)
        {
            _signalrContext = signalrContext;
        }

        public int TActiveCategoryCount()
        {
            return _signalrContext.Categories.Count(x => x.Status == true);
        }

        public int TCategoryCount()
        {
            return _signalrContext.Categories.Count();
        }

        public int TPassiveCategoryCount()
        {
            return _signalrContext.Categories.Count(x => x.Status == false);
        }
    }
}
