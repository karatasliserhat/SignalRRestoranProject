using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Abstract
{
    public interface IDiscountService:IGenericService<Discount>
    {
        Task ChangeStautusTrue(int id);
        Task ChangeStautusFalse(int id);
        Task<List<Discount>> StatusTrueList();
    }
}
