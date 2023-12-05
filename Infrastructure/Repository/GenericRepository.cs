using Domain.Interfaces.Repository;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SeguridadContexto _seguridadContexto;

        public GenericRepository(SeguridadContexto seguridadContexto)
        {
            _seguridadContexto = seguridadContexto;
        }

        public async Task Add(T entity)
        {
            _seguridadContexto.Set<T>().AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            _seguridadContexto.Set<T>().Remove(entity);
        }

        public async Task<T> Find(Guid Id)
        {
            var entity=await _seguridadContexto.Set<T>().FindAsync(Id);
            return entity;
        }
    }
}
