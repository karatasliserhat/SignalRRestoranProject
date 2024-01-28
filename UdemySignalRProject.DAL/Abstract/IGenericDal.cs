namespace UdemySignalRProject.DAL.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> GetById(int id);
        IQueryable<T> GetAllQueryable();
        Task<List<T>> GetAll();
    }
}
