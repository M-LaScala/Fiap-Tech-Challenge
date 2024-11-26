using MediatR;

namespace Tech.Challenge.Grupo27.Application.AtualizarContato
{
    public class AtualizarContatoRequest : ContatoRequest, IRequest<ContatoResponse>
    {
        public Guid Id { get; set; }
    }
}
