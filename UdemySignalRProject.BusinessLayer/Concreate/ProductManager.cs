using Microsoft.EntityFrameworkCore;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;
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
            var datas = await _context.Products.Include(x => x.Category).ToListAsync();

            return datas;
        }

        public int TProductCountByCategoryNameDrink()
        {
            return _context.Products.Include(x => x.Category).Where(x => x.Category.CategoryName == "İçecek").ToList().Count();
        }

        public int TProductCountByCategoryNameHamburger()
        {
            return _context.Products.Include(x => x.Category).Where(x => x.Category.CategoryName == "Hamburger").ToList().Count();
        }

        public int TProductCount()
        {
            return _context.Products.Count();
        }

        public decimal TProductPriceAvg()
        {
            return _context.Products.Average(x => x.Price);
        }

        public string TProductMinPrice()
        {
            return _context.Products.Where(x => x.Price == (_context.Products.Min(x => x.Price))).Select(x => x.ProductName).FirstOrDefault();

            //return _context.Products.OrderByDescending(x => x.Price).Select(x => x.ProductName).FirstOrDefault();
        }

        public string TProductMaxPrice()
        {
            //return _context.Products.OrderByDescending(x => x.Price).Select(x => x.ProductName).FirstOrDefault();

            return _context.Products.Where(x => x.Price == (_context.Products.Max(x => x.Price))).Select(x => x.ProductName).FirstOrDefault();
        }

        public decimal TProductAvgByCategoryNameHamburger()
        {

            //_context.Products.Where(x => x.CategoryId == (_context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryId)).FirstOrDefault()).Average(x => x.Price);

            return _context.Products.Include(x => x.Category).Where(x => x.Category.CategoryName == "Hamburger").Average(x => x.Price);
        }
    }
}
