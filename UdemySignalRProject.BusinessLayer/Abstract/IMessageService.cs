using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        Task ChangeStautusFalse(int id);
        Task ChangeStautusTrue(int id);
        Task<List<Message>> StatusFalseList();
    }
}
