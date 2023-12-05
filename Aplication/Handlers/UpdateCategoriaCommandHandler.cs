using Aplication.Commands;
using Domain.Entities;
using Domain.Interfaces.Repository;
using MediatR;

namespace Aplication.Handlers
{
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, Categoria>
    {
        private readonly IRepository _catRepository;

        public UpdateCategoriaCommandHandler(IRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Categoria> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var cat =await _catRepository.GetByIdAsync(request.Id);

            if (cat is null) throw new InvalidOperationException("Categoria does not exist");

            cat.Descripcion = request.Descripcion;
            cat.Estado = request.Estado;

            await _catRepository.UpdateAsync(cat);
            return cat;
        }
    }
}
