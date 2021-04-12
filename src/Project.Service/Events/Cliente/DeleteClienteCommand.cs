using FluentValidation;
using Project.Service.Commands;
using System;

namespace Project.Service.Events
{
    public class DeleteClienteCommand : Command
    {
        public Guid Id { get; private set; }
        public DeleteClienteCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class DeleteClienteCommandValidation : AbstractValidator<DeleteClienteCommand>
    {
        public DeleteClienteCommandValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Campo Id inválido");
        }
    }
}
