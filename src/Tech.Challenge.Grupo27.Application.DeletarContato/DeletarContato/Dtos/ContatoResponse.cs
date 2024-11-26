using Tech.Challenge.Grupo27.Application.Shared;

namespace Tech.Challenge.Grupo27.Application.DeletarContato
{
    public class ContatoResponse : ResponseDto
    {
        public object? Data { get; set; }

        public ContatoResponse() { }

        public ContatoResponse(string mensagem, bool sucesso, object? data) : base(sucesso, mensagem)
        {
            Data = data;
        }
    }
}
