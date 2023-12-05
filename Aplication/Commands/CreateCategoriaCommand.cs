using Domain.Dtos;
using Domain.Entities;
using MediatR;

namespace Aplication.Commands
{
    public class CreateCategoriaCommand:IRequest<Categoria>
    {
        public readonly CategoriaDto CatDto;
        public readonly Guid Id;

        public CreateCategoriaCommand(CategoriaDto catDto, Guid id)
        {
            CatDto= catDto;
            Id=id;
        }
    }
}
