using Tech.Challenge.Grupo27.Infrastructure.Domain.Models.Shared;

namespace Tech.Challenge.Grupo27.Infrastructure.Domain.Models.RegioesDddAggregate
{
    public class RegiaoDddEntity : EntityBase
    {
        public int Codigo { get; private set; }

        public string Estado { get; private set; }

        public string Descricao { get; private set; }

        public RegiaoDddEntity(int codigo, string descricao, string estado)
        {
            Codigo = codigo;
            Estado = estado;
            Descricao = descricao;
        }
    }
}
