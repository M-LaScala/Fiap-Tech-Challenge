using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.Shared;
using Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;

namespace Tech.Challenge.Grupo27.Application.Contatos.AtualizarContato.Handler_
{
    public class AtualizarContatoHandler : IHandler<AtualizarContatoRequest, ContatoResponse>
    {
        private readonly IContatoAtualizadoProducer _contatoProducer;
        private readonly INotificacaoContext _notificacaoContext;

        public AtualizarContatoHandler
        (
            IContatoAtualizadoProducer contatoProducer,
            INotificacaoContext notificacaoContext)
        {
            _contatoProducer = contatoProducer;
            _notificacaoContext = notificacaoContext;
        }

        public async Task<ContatoResponse> Handle(AtualizarContatoRequest request, CancellationToken cancellationToken)
        {
            var contato = new Contato
            (                
                request.Nome,
                request.Email,
                new Domain.Shared.ValueObject.Telefone(request.Telefone.Ddd, request.Telefone.Numero),
                request.Id
             );

            if (contato.Invalid)
            {
                _notificacaoContext.AddNotificacoes(contato.ValidationResult!);
                return new ContatoResponse("", false, null);
            }

            await _contatoProducer.AtualizarContato(new Domain.Commands.ContatoAtualizadoCommand()
            {
                Id = contato.Id,
                Email = contato.Email,
                Nome = contato.Nome,
                Telefone = new Domain.Commands.TelefoneCommand()
                {
                    Ddd = contato.Telefone?.Ddd,
                    Numero = contato.Telefone?.Numero
                }
            });

            return new ContatoResponse("Solicitação de atualização de contato realizado com sucesso", true, new { request.Id });
        }
    }
}
