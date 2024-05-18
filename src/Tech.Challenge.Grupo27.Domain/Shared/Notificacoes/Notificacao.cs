namespace Tech.Challenge.Grupo27.Domain.Shared.Notificacoes
{
    public class Notificacao
    {
        public string? Mensagem { get; set; }

        public string? Codigo { get; set; }

        public Notificacao(string? mensagem, string? codigo)
        {
            Mensagem = mensagem;
            Codigo = codigo;
        }
    }
}
