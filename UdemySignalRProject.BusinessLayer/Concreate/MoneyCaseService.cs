using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class MoneyCaseService : GenericManager<MoneyCase>, IMoneyCaseService
    {
        private readonly SignalRContext _context;
        public MoneyCaseService(IGenericDal<MoneyCase> generiDal, IUnitOfWork unitOfWork, SignalRContext context) : base(generiDal, unitOfWork)
        {
            _context = context;
        }

        public decimal TGetMoneyCaseTotalAmaount()
        {
            return _context.MoneyCases.Sum(x => x.TotalAmaount);
        }
    }
}
