using Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Dtos;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.Shared;
using Tech.Challenge.Grupo27.Domain.Services;

namespace Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Handler_
{
    public class ObterContatoPorIdHandler : IHandler<ObterPorIdRequest, ContatoResponse>
    {
        private readonly IContatoService _contatoService;

        public ObterContatoPorIdHandler(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public async Task<ContatoResponse> Handle(ObterPorIdRequest request, CancellationToken cancellationToken)
        {
            var contato = await _contatoService.ObterPorId(request.Id);

            if (contato is null || contato.Id == Guid.Empty)
            {
                var mensagem = $"Contato não encotrado para o Id: {request.Id}";
                return new ContatoResponse(mensagem, false, null);
            }

            return new ContatoResponse
            (
                "contato encontrado",
                true,
                new ObterContatoResponse
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
