using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class MenutTableService : GenericManager<MenuTable>, IMenuTableService
    {
        private readonly SignalRContext _context;
        public MenutTableService(IGenericDal<MenuTable> generiDal, IUnitOfWork unitOfWork, SignalRContext context) : base(generiDal, unitOfWork)
        {
            _context = context;
        }

        public int TMenuTableCount()
        {
            return _context.MenuTables.Count();
        }
    }
}
