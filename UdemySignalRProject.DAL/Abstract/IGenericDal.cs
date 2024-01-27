namespace UdemySignalRProject.DAL.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        IQueryable<T> GetAllQueryable();
        List<T> GetAll();
    }
}
