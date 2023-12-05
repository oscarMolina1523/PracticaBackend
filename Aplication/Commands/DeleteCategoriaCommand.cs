using MediatR;

namespace Aplication.Commands
{
    public class DeleteCategoriaCommand:IRequest
    {
        public Guid Id { get; set; }

        public DeleteCategoriaCommand(Guid id)
        {
            this.Id= id;
        }
    }
}
