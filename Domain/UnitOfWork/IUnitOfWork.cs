using Domain.Interfaces.Repository;

namespace Domain.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task CommitAsync();
        void Rollback();
    }
}
