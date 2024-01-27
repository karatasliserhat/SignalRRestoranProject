namespace UdemySignalRProject.DAL.Abstract
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
