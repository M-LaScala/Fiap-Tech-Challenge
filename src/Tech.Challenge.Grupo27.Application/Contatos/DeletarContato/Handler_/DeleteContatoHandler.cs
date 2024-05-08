using Tech.Challenge.Grupo27.Application.Contatos.DeletarContato.Dtos;
using Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Dtos;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.Shared;
using Tech.Challenge.Grupo27.Domain.Services;

namespace Tech.Challenge.Grupo27.Application.Contatos.DeletarContato.Handler_
{
    internal class DeleteContatoHandler : IHandler<DeleteContatoRequest, ContatoResponse>
    {
        private readonly IContatoService _contatoService;

        public DeleteContatoHandler(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public async Task<ContatoResponse> Handle(DeleteContatoRequest request, CancellationToken cancellationToken)
        {
            var contato = await _contatoService.Delete(request.Id, cancellationToken);

            if (contato is null)
            {
                return new ContatoResponse("", false, null);
            }

            return new ContatoResponse
            (
                "Contato removido com sucesso",
                true,
                new DeleteContatoResponse
                (
                    contato.Id,
                    contato.Nome,
                    contato.Email,
                    new TelefoneResponse
                    (
                        contato.Telefone.Numero,
                        contato.Telefone.Ddd,
                        contato.Telefone.Estado,
                        contato.Telefone.Regiao
                     )
                  )
            );
        }
    }
}
