using Microsoft.EntityFrameworkCore;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class MessageService : GenericManager<Message>, IMessageService
    {
        private readonly SignalRContext _context;
        public MessageService(IGenericDal<Message> generiDal, IUnitOfWork unitOfWork, SignalRContext context) : base(generiDal, unitOfWork)
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

        public async Task<List<Message>> StatusFalseList()
        {
            return await _context.Messages.Where(x => x.Status == false).ToListAsync();

        }
    }
}
