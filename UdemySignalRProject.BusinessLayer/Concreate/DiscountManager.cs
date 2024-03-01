using Microsoft.EntityFrameworkCore;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class DiscountManager : GenericManager<Discount>, IDiscountService
    {
        private readonly SignalRContext _context;
        public DiscountManager(IGenericDal<Discount> generiDal, IUnitOfWork unitOfWork, SignalRContext context) : base(generiDal, unitOfWork)
        {
            _context = context;
        }

        public async Task ChangeStautusFalse(int id)
        {
            await _context.Discounts.Where(x => x.DiscountId == id).ExecuteUpdateAsync(x => x.SetProperty(y => y.Status, false));
        }

        public async Task ChangeStautusTrue(int id)
        {
            await _context.Discounts.Where(x => x.DiscountId == id).ExecuteUpdateAsync(x => x.SetProperty(y => y.Status, true));
        }

        public async Task<List<Discount>> StatusTrueList()
        {
            return await _context.Discounts.Where(x => x.Status == true).ToListAsync();
            
        }
    }
}
