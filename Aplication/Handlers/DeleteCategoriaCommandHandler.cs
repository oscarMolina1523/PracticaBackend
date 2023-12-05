using Aplication.Commands;
using Domain.Interfaces.Repository;
using MediatR;

namespace Aplication.Handlers
{
    public class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand>
    {
        private readonly IRepository _catRepostory;

        public DeleteCategoriaCommandHandler(IRepository catRepository)
        {
            _catRepostory = catRepository;
        }

        public async Task Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
            var cat = await _catRepostory.GetByIdAsync(request.Id);
            if (cat is null) throw new InvalidOperationException("Categoria does not exist");

            await _catRepostory.DeleteAsync(cat);
        }
    }
}
