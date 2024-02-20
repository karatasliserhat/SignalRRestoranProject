using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.BusinessLayer.Abstract
{
    public interface IMenuTableService:IGenericService<MenuTable>
    {
        int TMenuTableCount();
    }
}
