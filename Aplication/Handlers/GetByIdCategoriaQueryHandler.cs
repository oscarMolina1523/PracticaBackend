using Aplication.Queries;
using Domain.Entities;
using Domain.Interfaces.Repository;
using MediatR;

namespace Aplication.Handlers
{
    public class GetByIdCategoriaQueryHandler : IRequestHandler<GetByIdCategoriaQuery, Categoria>
    {
        private readonly IRepository _catRepository;

        public GetByIdCategoriaQueryHandler(IRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Categoria> Handle(GetByIdCategoriaQuery request, CancellationToken cancellationToken)
        {
            var cat = await _catRepository.GetByIdAsync(request.Id);
            return cat;
        }
    }
}
