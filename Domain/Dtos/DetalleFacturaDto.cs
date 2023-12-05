namespace Domain.Dtos
{
    public class DetalleFacturaDto
    {
        public Guid IdProducto { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal SubTotal { get; set; }
    }
}
