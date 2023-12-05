using Domain.Entities;

namespace Domain.Interfaces.Repository
{
    public interface IRepository
    {
        Task CreateAsync(Categoria categoria);
        Task DeleteAsync(Categoria categoria);
        Task UpdateAsync(Categoria categoria);
        Task<List<Categoria>> GetAsync();
        Task<Categoria> GetByIdAsync(Guid id);
    }
}
