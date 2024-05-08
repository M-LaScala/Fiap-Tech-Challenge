namespace Tech.Challenge.Grupo27.Domain.Models.RegioesDddAggregate
{
    public class RegiaoDdd
    {
        public Guid Id { get; private set; }
        public int Codigo { get; private set; }

        public string Estado { get; private set; }

        public string Descricao { get; private set; }

        public RegiaoDdd(Guid id, int codigo, string estado, string descricao)
        {
            Id = id;
            Codigo = codigo;
            Estado = estado;
            Descricao = descricao;
        }
    }
}
