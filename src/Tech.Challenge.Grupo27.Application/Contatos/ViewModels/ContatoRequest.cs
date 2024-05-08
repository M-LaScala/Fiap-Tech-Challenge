using MediatR;
using Tech.Challenge.Grupo27.Application.Shared;

namespace Tech.Challenge.Grupo27.Application.Contatos.ViewModels
{
    public class ContatoRequest : RequestDto, IRequest<ContatoResponse>
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Numero { get; set; }

        public string? Ddd { get; set; }
    }
}
