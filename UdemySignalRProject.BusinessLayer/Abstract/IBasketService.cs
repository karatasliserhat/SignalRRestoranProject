using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        Task<List<Basket>> TGetBasketByMenuTableNumberAsync(int id);
    }
}
