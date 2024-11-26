using MediatR;
using Tech.Challenge.Grupo27.Application.Shared;

namespace Tech.Challenge.Grupo27.Application.DeletarContato
{
    public class DeleteContatoRequest : RequestDto, IRequest<ContatoResponse>
    {
        public Guid? Id { get; set; }

        public DeleteContatoRequest(Guid? id)
        {
            Id = id;
        }
    }
}
