using MediatR;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;

namespace Tech.Challenge.Grupo27.Application.Contatos.AtualizarContato
{
    public class AtualizarContatoRequest : ContatoRequest, IRequest<ContatoResponse>
    {
        public Guid Id { get; set; }
    }
}
