using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DAL.Abstract;

namespace UdemySignalRProject.BusinessLayer.Concreate
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _generiDal;
        private readonly IUnitOfWork _unitOfWork;
        public GenericManager(IGenericDal<T> generiDal, IUnitOfWork unitOfWork)
        {
            _generiDal = generiDal;
            _unitOfWork = unitOfWork;
        }

        public async Task TAddAsync(T entity)
        {
            await _generiDal.Add(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task TDeleteAsync(T entity)
        {
             _generiDal.Delete(entity);
            await _unitOfWork.CommitAsync();
        }

        public  async Task<List<T>> TGetAllAsync()
        {
             return await _generiDal.GetAll();
        }

        public IQueryable<T> TGetAllQueryable()
        {
           return _generiDal.GetAllQueryable();
        }

        public async Task<T> TGetByIdAsync(int id)
        {
            return await _generiDal.GetById(id);
        }

        public async Task TUpdateAsync(T entity)
        {
            _generiDal.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
