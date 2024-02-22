using Microsoft.EntityFrameworkCore;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class BasketService : GenericManager<Basket>, IBasketService
    {
        private readonly SignalRContext _context;
        public BasketService(IGenericDal<Basket> generiDal, IUnitOfWork unitOfWork, SignalRContext context) : base(generiDal, unitOfWork)
        {
            _context = context;
        }

        public async Task<List<Basket>> TGetBasketByMenuTableNumberAsync(int id)
        {

            return await _context.Baskets.Include(x => x.Product).Include(x => x.MenuTable).Where(x => x.MenuTableId == id).ToListAsync();
        }
    }
}
