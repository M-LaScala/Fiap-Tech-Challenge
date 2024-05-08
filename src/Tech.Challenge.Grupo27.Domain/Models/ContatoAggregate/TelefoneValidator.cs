using FluentValidation;
using Tech.Challenge.Grupo27.Domain.Shared.ValueObject;

namespace Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate
{
    internal class TelefoneValidator : AbstractValidator<Telefone>
    {
        public TelefoneValidator()
        {

            RuleFor(contato => contato.Numero)
                .NotEmpty()
                .WithMessage("Número é obrigatório.")
                .WithErrorCode("NUMERO_OBRIGATORIO")
                .MaximumLength(80)
                .WithMessage("O número deve ter no máximo 10 caracteres.")
                .WithErrorCode("NUMERO_TAMANHO_MAXIMO");

            RuleFor(contato => contato)
                .Must(c => c.ValidarNumero(c.Numero))
                .WithMessage("Número de telefone inválido")
                .WithErrorCode("NUMERO_INVALIDO");

            RuleFor(contato => contato.Ddd)
                .NotEmpty()
                .WithMessage("DDD é obrigatório.")
                .WithMessage("DDD é obrigatório.")
                .Length(2)
                .WithMessage("O DDD deve conter 2 caracteres.")
                .WithErrorCode("DDD_TAMANHO");

            RuleFor(contato => contato)
                .Must(c => c.ValidarDdd(c.Ddd))
                .WithMessage("DDD de telefone inválido")
                .WithErrorCode("DDD_INVALIDO");
        }
    }
}
