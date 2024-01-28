using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        public ProductManager(DAL.Abstract.IGenericDal<Product> generiDal, DAL.Abstract.IUnitOfWork unitOfWork) : base(generiDal, unitOfWork)
        {
        }
    }
}
