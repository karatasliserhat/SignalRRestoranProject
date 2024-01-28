namespace UdemySignalRProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TAddAsync(T entity);
        Task TDeleteAsync(T entity);
        Task TUpdateAsync(T entity);
        Task<T> TGetByIdAsync(int id);
        IQueryable<T> TGetAllQueryable();
        Task<List<T>> TGetAllAsync();
    }
}
