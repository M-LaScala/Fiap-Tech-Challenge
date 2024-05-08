using MediatR;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.Shared;

namespace Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Dtos
{
    public class ObterPorIdRequest : RequestDto, IRequest<ContatoResponse>
    {
        public Guid? Id { get; set; }

        public ObterPorIdRequest(Guid? id)
        {
            Id = id;
        }
    }
}
