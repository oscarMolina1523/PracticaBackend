using Domain.Entities;
using MediatR;

namespace Aplication.Queries
{
    public class GetAllCategoriaQuery:IRequest<List<Categoria>>
    {

    }
}
