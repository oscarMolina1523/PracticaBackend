using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IService
    {
        Task<List<Factura>> Get();
        Task<Factura> GetByIdAsync(Guid id);
        Task<Factura> createAsync(FacturaDto facturaDto);
        Task DeleteAsync(Guid id);
    }
}
