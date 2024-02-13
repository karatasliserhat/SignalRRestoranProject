using Microsoft.EntityFrameworkCore;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;
using UdemySignalRProject.DTO.Dtos.ProductDto;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        private readonly SignalRContext _context;

        public ProductManager(IGenericDal<Product> generiDal, IUnitOfWork unitOfWork, SignalRContext context) : base(generiDal, unitOfWork)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsWithCategories()
        {
            var datas= await _context.Products.Include(x => x.Category).ToListAsync();

            return datas;
        }
    }
}
