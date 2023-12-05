using Domain.Entities;

namespace Domain.Dtos
{
    public class FacturaDto
    {
        public Guid IdCliente { get; set; }

        public Guid IdEmpleado { get; set; }

        public List<DetalleFactura> Detalles { get; set; }
    }
}
