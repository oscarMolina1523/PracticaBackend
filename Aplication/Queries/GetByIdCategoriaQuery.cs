using Domain.Entities;
using MediatR;

namespace Aplication.Queries
{
    public class GetByIdCategoriaQuery:IRequest<Categoria>
    {
        public Guid Id { get; set; }

        public GetByIdCategoriaQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
