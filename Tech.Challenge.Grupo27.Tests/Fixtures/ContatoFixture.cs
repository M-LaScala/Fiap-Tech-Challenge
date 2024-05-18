using Bogus;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Shared.ValueObject;

namespace Tech.Challenge.Grupo27.Tests.Fixtures
{
    public class ContatoFixture
    {
        public Contato ObterContatoMock(Guid id)
        {
            var contato = new Faker<Contato>()
                .RuleFor(c=> c.Id, id)
                .RuleFor(c => c.Nome, f => f.Person.FullName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.Telefone, f => new Telefone("11", f.Person.Phone));
            
            return contato;
        }

        public IEnumerable<Contato> ObterContatosMock()
        {
            var contato = new Faker<Contato>()
                .RuleFor(c => c.Id, Guid.NewGuid())
                .RuleFor(c => c.Nome, f => f.Person.FullName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.Telefone, f => new Telefone("11", f.Person.Phone));

            return contato.Generate(5);
        }
    }
}
