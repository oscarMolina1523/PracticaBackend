using Domain.Dtos;
using Domain.Entities;
using MediatR;

namespace Aplication.Commands
{
    public class UpdateCategoriaCommand : IRequest<Categoria>
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public UpdateCategoriaCommand(Guid id, string Descripcion, bool Estado)
        {
            this.Id= id;
            this.Descripcion = Descripcion;
            this.Estado = Estado;
        }
    }
}
