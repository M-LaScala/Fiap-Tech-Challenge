namespace Tech.Challenge.Grupo27.Domain.Shared.Exceptions
{
    public class ErroMensagem : Exception
    {
        public string? Mensagem { get; set; }

        public string? Codigo { get; set; }

        public ErroMensagem(string? codigo, string? mensagem): base(mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }
    }
}
