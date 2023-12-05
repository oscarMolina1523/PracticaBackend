using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.UnitOfWork;

namespace Domain.Servicios
{
    public class Service : IService
    {
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public async Task<Factura> createAsync(FacturaDto facturaDto)
        {
            try
            {
                var factura = new Factura
                {
                    IdCliente = facturaDto.IdCliente,
                    IdEmpleado = facturaDto.IdEmpleado,
                    Total = facturaDto.Detalles.Sum(d => d.Cantidad * d.Precio),
                    Fecha = DateTime.Now
                };

                await _unitOfWork.Repository<Factura>().Add(factura);

                foreach (var detalle in facturaDto.Detalles)
                {
                    var detalleFactura = new DetalleFactura
                    {
                        IdProducto = detalle.IdProducto,
                        Cantidad = detalle.Cantidad,
                        Precio = detalle.Precio,
                        SubTotal = detalle.Cantidad * detalle.Precio,
                        IdFactura = factura.IdFactura
                    };

                    await _unitOfWork.Repository<DetalleFactura>().Add(detalleFactura);
                }

                await _unitOfWork.CommitAsync();

                return factura;
            }
            catch 
            {
                _unitOfWork.Rollback();
                _unitOfWork.Dispose();
                throw;
            }
        }

        

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var factTask = _unitOfWork.Repository<Factura>().Find(id);
                var fact = factTask.Result;
                await _unitOfWork.Repository<Factura>().Delete(fact);
                var detallesList = fact.Detalles.ToList();
                foreach (var detalles in detallesList)
                {
                    await _unitOfWork.Repository<DetalleFactura>().Delete(detalles);
                }
                await _unitOfWork.CommitAsync();
            }
            catch 
            {
                _unitOfWork.Rollback();
                _unitOfWork.Dispose();
                throw;
            }
        }

        public Task<List<Factura>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Factura> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
