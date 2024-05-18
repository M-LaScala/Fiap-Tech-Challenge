using Tech.Challenge.Grupo27.Domain.Models.RegioesDddAggregate;

namespace Tech.Challenge.Grupo27.Tests.Fixtures
{
    public class RegiaoDddFixture
    {
        public RegiaoDdd ObterRegiaoDddMock()
        {
            return new RegiaoDdd(Guid.NewGuid(),11, "SP", "Sudeste");
            
        }
    }
}
