using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class SeguridadContexto : IdentityDbContext<Usuario>
    {
        public SeguridadContexto(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Factura> Facturas { get; set; }

        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
    }
}
