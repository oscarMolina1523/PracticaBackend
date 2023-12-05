using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Factura
    {
        [Key]
        public Guid IdFactura { get; set; }

        public Guid IdCliente { get; set; }

        public decimal Total { get; set; }

        public DateTime Fecha { get; set; }

        public Guid IdEmpleado { get; set; }

        //este significa que no se mapeara en la base de datos
        [NotMapped]
        public virtual List<DetalleFactura> Detalles { get; set; }
    }
}
