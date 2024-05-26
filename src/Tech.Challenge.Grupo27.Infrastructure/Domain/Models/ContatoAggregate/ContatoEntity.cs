using Tech.Challenge.Grupo27.Infrastructure.Domain.Models.Shared;

namespace Tech.Challenge.Grupo27.Infrastructure.Domain.Models.ContatoAggregate
{
    public class ContatoEntity : EntityBase
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? NumeroTelefone { get; set; }

        public string? Ddd { get; set; }

        public ContatoEntity(string? nome, string? email, string? numeroTelefone, string? ddd)
        {
            Nome = nome;
            Email = email;
            NumeroTelefone = numeroTelefone;
            Ddd = ddd;
        }
    }
}
