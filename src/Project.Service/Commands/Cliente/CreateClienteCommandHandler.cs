using MediatR;
using Project.Model.Entities;
using Project.Model.Notifications;
using Project.Model.Repository.Interfaces;
using Project.Service.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Service.Commands
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IClienteRepository _repositoryWrite;

        public CreateClienteCommandHandler(IMediator mediator, IClienteRepository repositoryWrite)
        {
            _mediator = mediator;
            _repositoryWrite = repositoryWrite;
        }

        public async Task<bool> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            if (!ValidadeCommand(request)) return false;

            var entity = new Cliente
            {
                Id = request.Id,
                Nome = request.Nome,
                Idade = request.Idade
            };

            await _repositoryWrite.Create(entity);

            return true;
        }

        private bool ValidadeCommand(Command request)
        {
            if (request.IsValid()) return true;

            foreach (var error in request.ValidationResult.Errors)
            {
                _mediator.Publish(new DomainNotification(error.ErrorMessage));
            }

            return false;
        }
    }
}
