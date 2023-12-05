using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class Repository : IRepository
    {
        private readonly SeguridadContexto _seguridadContexto;

        public Repository(SeguridadContexto seguridadContexto)
        {
            _seguridadContexto = seguridadContexto;
        }

        public async Task CreateAsync(Categoria categoria)
        {
            _seguridadContexto.Categoria.Add(categoria);
            await _seguridadContexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(Categoria categoria)
        {
            var catDelete = await _seguridadContexto.Categoria.FindAsync(categoria.Id);
            if (catDelete is not null) {
                _seguridadContexto.Categoria.Remove(catDelete);
                _seguridadContexto.SaveChanges();
            }
        }

        public async Task<List<Categoria>> GetAsync()
        {
            return await _seguridadContexto.Categoria.ToListAsync();
        }

        public async Task<Categoria> GetByIdAsync(Guid id)
        {
            //tambien se puede usar el findAsync  seria como .FindAsync(id) nada mas
            var catFilter = await _seguridadContexto.Categoria.FindAsync(id);
            if (catFilter is null)
            {
                throw new InvalidOperationException("Categoria does not exist");
            }
            return catFilter;
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            if (categoria is null)
            {
                throw new InvalidOperationException("Categoria does not exist");
            }
            _seguridadContexto.Categoria.Update(categoria);
            await _seguridadContexto.SaveChangesAsync();
        }
    }
}
