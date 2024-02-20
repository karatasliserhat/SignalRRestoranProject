using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Abstract
{
    public interface IMoneyCaseService:IGenericService<MoneyCase>
    {
        decimal TGetMoneyCaseTotalAmaount();
    }
}
