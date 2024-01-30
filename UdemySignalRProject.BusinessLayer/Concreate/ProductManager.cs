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

        public async Task<List<ResultProductWithGetCategory>> GetProductsWithCategories()
        {
            return await _context.Products.Include(x => x.Category).Select(y => new ResultProductWithGetCategory
            {
                CategoryId = y.CategoryId,
                CategoryName = y.Category.CategoryName,
                ProductId = y.ProductId,
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,

            }).ToListAsync();
        }
    }
}
