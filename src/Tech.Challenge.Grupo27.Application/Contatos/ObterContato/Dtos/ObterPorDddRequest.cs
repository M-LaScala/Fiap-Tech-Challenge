using MediatR;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.Shared;

namespace Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Dtos
{
    public class ObterPorDddRequest : RequestDto, IRequest<ContatoResponse>
    {
        public int? Ddd { get; set; }

        public ObterPorDddRequest(int? ddd)
        {
            Ddd = ddd;
        }
    }
}
