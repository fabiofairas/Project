using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Model.DTOs;
using Project.Model.Notifications;
using Project.Model.Repository.Interfaces;
using Project.Service.Events;
using Project.Service.Notifications;
using System;
using System.Threading.Tasks;

namespace Project.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IMediator _mediator;
        private readonly DomainNotificationHandler _notifications;
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IMediator mediator, INotificationHandler<DomainNotification> notifications, IClienteRepository clienteRepository)
        {
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _clienteRepository.List();

            if (_notifications.HasNotification())
                return BadRequest(_notifications.ListNotifications());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _clienteRepository.Get(id);

            if (_notifications.HasNotification())
                return BadRequest(_notifications.ListNotifications());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteRequest request)
        {            
            await _mediator.Send(new CreateClienteCommand(request.Id, request.Nome, request.Idade));

            if (_notifications.HasNotification())
                return BadRequest(_notifications.ListNotifications());

            return Ok(request.Id);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update(Guid id, ClienteRequest request)
        {
            await _mediator.Send(new UpdateClienteCommand(id, request.Nome, request.Idade));

            if (_notifications.HasNotification())
                return BadRequest(_notifications.ListNotifications());

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteClienteCommand(id));

            if (_notifications.HasNotification())
                return BadRequest(_notifications.ListNotifications());

            return Ok();
        }
    }
}