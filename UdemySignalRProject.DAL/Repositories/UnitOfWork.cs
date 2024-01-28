using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;

namespace UdemySignalRProject.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SignalRContext _context;

        public UnitOfWork(SignalRContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
