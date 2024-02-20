using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class OrderService : GenericManager<Order>, IOrderService
    {
        private readonly SignalRContext _context;
        public OrderService(IGenericDal<Order> generiDal, IUnitOfWork unitOfWork, SignalRContext context) : base(generiDal, unitOfWork)
        {
            _context = context;
        }

        public int TActiveOrderCount()
        {
            return _context.Orders.Where(x => x.Description == "Müşteri Masada").ToList().Count();
        }

        public decimal TLastOrderPrice()
        {
            return _context.Orders.OrderByDescending(x => x.OrderId).Select(x => x.TotalPrice).FirstOrDefault();
        }

        public int TTotalOrderCount()
        {
            return _context.Orders.Count();
        }

        public decimal TDateNowTotalPrice()
        {
            return _context.Orders.Where(x => x.Date==DateTime.Now.Date).Sum(x => x.TotalPrice);
        }
    }
}
