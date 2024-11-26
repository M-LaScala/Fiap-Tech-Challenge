using Tech.Challenge.Grupo27.Application.Shared;
using Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker;
using Tech.Challenge.Grupo27.Domain.Services;

namespace Tech.Challenge.Grupo27.Application.DeletarContato
{
    public class DeleteContatoHandler : IHandler<DeleteContatoRequest, ContatoResponse>
    {
        private readonly IContatoDeletadoProducer _contatoProducer;
        private readonly IContatoService _contatoService;
        public DeleteContatoHandler(IContatoService contatoService, IContatoDeletadoProducer contatoProducer)
        {
            _contatoService = contatoService;
            _contatoProducer = contatoProducer;
        }

        public async Task<ContatoResponse> Handle(DeleteContatoRequest request, CancellationToken cancellationToken)
        {
            var contato = await _contatoService.ObterPorId(request.Id);

            if (contato is null)
            {
                return new ContatoResponse("Contato não encontrado", false, null);
            }

           await _contatoProducer.DeleteContato(new Domain.Commands.ContatoDeletadoCommand() { Id = request.Id });

            return new ContatoResponse
            (
                "Solicitação de delete realizado com sucesso",
                true,
                new DeleteContatoResponse
                (
                    contato.Id,
                    contato.Nome,
                    contato.Email,
                    new TelefoneResponse
                    (
                        contato.Telefone?.Numero,
                        contato.Telefone?.Ddd,
                        contato.Telefone?.Estado,
                        contato.Telefone?.Regiao
                     )                
                  )
            );
        }
    }
}
