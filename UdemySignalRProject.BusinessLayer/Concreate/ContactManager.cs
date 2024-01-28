using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class ContactManager : GenericManager<Contact>, IContactService
    {
        public ContactManager(IGenericDal<Contact> generiDal, IUnitOfWork unitOfWork) : base(generiDal, unitOfWork)
        {
        }
    }
}
