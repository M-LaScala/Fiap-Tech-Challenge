using FluentValidation;

namespace Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate
{
    internal class ContatoValidator : AbstractValidator<Contato>
    {
        public ContatoValidator()
        {
            RuleFor(contato => contato.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.")
                .WithErrorCode("NOME_OBRIGATORIO")
                .MaximumLength(80)
                .WithMessage("O nome deve ter no máximo 80 caracteres.")
                .WithErrorCode("NOME_TAMANHO_MAXIMO");

            RuleFor(contato => contato.Email)
                .NotEmpty()
                .WithMessage("E-mail é obrigatório.")
                .WithErrorCode("EMAIL_OBRIGATORIO")
                .EmailAddress()
                .WithMessage("O e-mail não é válido")
                .WithErrorCode("EMAIL_INVALIDO");                 

            RuleFor(x=> x.Telefone).SetValidator(new TelefoneValidator());

        }
    }
}
