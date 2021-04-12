using FluentValidation.Results;
using MediatR;
using System;

namespace Project.Service.Commands
{
    public abstract class Command : IRequest<bool>
    {
        public ValidationResult ValidationResult { get; set; }
        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}