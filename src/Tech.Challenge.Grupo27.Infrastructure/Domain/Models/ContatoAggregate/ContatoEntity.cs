using Tech.Challenge.Grupo27.Infrastructure.Domain.Models.Shared;

namespace Tech.Challenge.Grupo27.Infrastructure.Domain.Models.ContatoAggregate
{
    public class ContatoEntity : EntityBase
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Telefone { get; set; }

        public string? Ddd { get; set; }

        public ContatoEntity(string? nome, string? email, string? telefone, string? ddd)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Ddd = ddd;
        }
    }
}
