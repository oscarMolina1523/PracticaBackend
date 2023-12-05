namespace Domain.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task<T> Find(Guid Id);
    }
}
