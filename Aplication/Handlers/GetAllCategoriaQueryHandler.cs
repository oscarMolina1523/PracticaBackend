using Aplication.Queries;
using Domain.Entities;
using Domain.Interfaces.Repository;
using MediatR;

namespace Aplication.Handlers
{
    public class GetAllCategoriaQueryHandler : IRequestHandler<GetAllCategoriaQuery, List<Categoria>>
    {
        private readonly IRepository catRepository;

        public GetAllCategoriaQueryHandler(IRepository catRepository)
        {
            this.catRepository = catRepository;
        }

        public Task<List<Categoria>> Handle(GetAllCategoriaQuery request, CancellationToken cancellationToken)
        {
            var categorias = catRepository.GetAsync();
            return categorias;
        }
    }
}
