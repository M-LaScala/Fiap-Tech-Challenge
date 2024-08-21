namespace Tech.Challenge.Grupo27.Application.Worker.Shared
{
    public class ResponseDto
    {
        public bool Sucesso { get; set; }

        public string? Mensagem { get; set; }

        public ResponseDto() { }

        public ResponseDto(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }
    }
}
