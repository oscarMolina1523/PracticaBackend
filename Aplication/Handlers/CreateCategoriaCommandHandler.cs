using Aplication.Commands;
using Domain.Entities;
using Domain.Interfaces.Repository;
using MediatR;

namespace Aplication.Handlers
{
    public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, Categoria>
    {
        private readonly IRepository _catRepository;

        public CreateCategoriaCommandHandler(IRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Categoria> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            Categoria cat = new Categoria
            {
                Id = Guid.NewGuid(),
                Descripcion = request.CatDto.Descripcion,
                Estado = request.CatDto.Estado
            };

            await _catRepository.CreateAsync(cat);
            return cat;
        }
    }
}
