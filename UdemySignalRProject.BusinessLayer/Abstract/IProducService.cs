using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        Task<List<Product>> GetProductsWithCategories();
    }
}
