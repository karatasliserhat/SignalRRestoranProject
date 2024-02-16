using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        Task<List<Product>> GetProductsWithCategories();

        int TProductCount();

        int TProductCountByCategoryNameHamburger();
        int TProductCountByCategoryNameDrink();

        decimal TProductPriceAvg();
        string TProductMinPrice();
        string TProductMaxPrice();
        decimal TProductAvgByCategoryNameHamburger();
    }
}
