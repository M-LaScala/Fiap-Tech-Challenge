namespace Tech.Challenge.Grupo27.Domain.Shared.ValueObject
{
    internal class RegiaoDdd
    {

        public string? Codigo { get; private set; }

        public string? Descricao { get; private set; }

        public RegiaoDdd(string? codigo, string? descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }
    }
}
