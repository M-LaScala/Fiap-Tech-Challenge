using Tech.Challenge.Grupo27.Domain.Models.Shared;
using Tech.Challenge.Grupo27.Domain.Shared.ValueObject;

namespace Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate
{
    public class Contato : CoreEntity
    {
        public string? Nome { get; private set; }

        public string? Email { get; private set; }

        public Telefone Telefone { get; private set; }

        public Contato() { }

        public Contato(string? nome, string? email, Telefone telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;

            Validate(this, new ContatoValidator());
        }

        public Contato(Guid id, string? nome, string? email, Telefone telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;

            Validate(this, new ContatoValidator());
        }
    }
}
