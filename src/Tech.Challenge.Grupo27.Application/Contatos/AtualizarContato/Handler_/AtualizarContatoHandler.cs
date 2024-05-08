using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.Shared;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;

namespace Tech.Challenge.Grupo27.Application.Contatos.AtualizarContato.Handler_
{
    internal class AtualizarContatoHandler : IHandler<AtualizarContatoRequest, ContatoResponse>
    {
        private readonly IContatoService _contatoService;
        private readonly INotificacaoContext _notificacaoContext;

        public AtualizarContatoHandler(IContatoService contatoService, INotificacaoContext notificacaoContext)
        {
            _contatoService = contatoService;
            _notificacaoContext = notificacaoContext;
        }

        public async Task<ContatoResponse> Handle(AtualizarContatoRequest request, CancellationToken cancellationToken)
        {
            var contato = new Contato
            (
                request.Id,
                request.Nome,
                request.Email,
                new Domain.Shared.ValueObject.Telefone(request.Ddd, request.Numero)
             );

            if (contato.Invalid)
            {
                _notificacaoContext.AddNotificacoes(contato.ValidationResult);
                return new ContatoResponse("", false, null);
            }

           await _contatoService.Aualizar(contato, cancellationToken);

            return new ContatoResponse("Contato atualizado com sucesso", true, new { Id = request.Id });
        }
    }
}
