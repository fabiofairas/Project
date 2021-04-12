using MediatR;
using Project.Model.Notifications;
using Project.Model.Repository.Interfaces;
using Project.Service.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Service.Commands
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IClienteRepository _repository;

        public UpdateClienteCommandHandler(IMediator mediator, IClienteRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            if (!ValidadeCommand(request)) return false;

            var entity = await _repository.Get(request.Id);

            if (entity != null)
            {
                entity.Nome = request.Nome;
                entity.Idade = request.Idade;

                await _repository.Update(entity);
            }
            else
            {
                await _mediator.Publish(new DomainNotification($"Id {request.Id} não encontrado"));
            }

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
