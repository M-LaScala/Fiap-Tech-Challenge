using Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Dtos;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.Shared;
using Tech.Challenge.Grupo27.Domain.Services;

namespace Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Handler_
{
    public class ObterContatosPorDddHandler : IHandler<ObterPorDddRequest, ContatoResponse>
    {
        private readonly IContatoService _contatoService;

        public ObterContatosPorDddHandler(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public async Task<ContatoResponse> Handle(ObterPorDddRequest request, CancellationToken cancellationToken)
        {
            var contatosResponse = new List<ObterContatoResponse>();

            var contatos = await _contatoService.ObterPorDdd(request?.Ddd?.ToString());


            if (contatos is null || contatos.Count() == 0)
            {
                var mensagem = $"Contato não encotrado para o DDD: {request?.Ddd}";
                return new ContatoResponse(mensagem, false, null);
            }

            foreach (var contato in contatos)
            {
                contatosResponse.Add
                (
                    new ObterContatoResponse
                    (
                        contato.Id,
                        contato.Nome,
                        contato.Email,
                        new TelefoneResponse
                        (
                            contato?.Telefone?.Numero,
                            contato?.Telefone?.Ddd,
                            contato?.Telefone?.Estado,
                            contato?.Telefone?.Regiao
                        )
                    )
                 );
            }

            return new ContatoResponse("contato encontrado", true, contatosResponse);
        }
    }
}
