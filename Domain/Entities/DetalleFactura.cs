using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class DetalleFactura
    {
        [Key]
        public Guid IdDetalle { get; set; }

        public Guid IdFactura { get; set; }

        public Guid IdProducto { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal SubTotal { get; set; }
    }
}
