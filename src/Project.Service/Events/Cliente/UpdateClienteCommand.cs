using FluentValidation;
using Project.Service.Commands;
using System;

namespace Project.Service.Events
{
    public class UpdateClienteCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }

        public UpdateClienteCommand(Guid id, string nome, int idade)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateClienteCommandValidation : AbstractValidator<UpdateClienteCommand>
    {
        public UpdateClienteCommandValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Campo Id inválido");

            RuleFor(c => c.Nome)
               .NotEmpty()
               .Must(x => x.Length <= 100)
               .WithMessage("Campo Nome inválido");

            RuleFor(c => c.Idade)
               .NotEmpty()
               .Must(x => x > 1 || x < 100)
               .WithMessage("Campo Idade inválido");
        }
    }
}
