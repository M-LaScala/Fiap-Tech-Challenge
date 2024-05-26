using Tech.Challenge.Grupo27.Domain.Models.Shared;
using Tech.Challenge.Grupo27.Domain.Shared.ValueObject;

namespace Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate
{
    public class Contato : CoreEntity
    {
        public string? Nome { get; private set; }

        public string? Email { get; private set; }

        public Telefone? Telefone { get; private set; }        

        public Contato() { }

        public Contato(string? nome, string? email, Telefone? telefone, Guid? id = null)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Id = id;
            Validate(this, new ContatoValidator());
        }

        public void AssociarDddContaARegiao(string? regiao, string? estado)
        {
            if ( !string.IsNullOrWhiteSpace(regiao) && !string.IsNullOrWhiteSpace(estado))
            {
                Telefone?.AdicionarRegiaoDoDdd(regiao, estado);
            }
        }
    }
}
