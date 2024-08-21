using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.Shared;
using Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;

namespace Tech.Challenge.Grupo27.Application.API.InserirContato.Handler_
{
    public class InserirContatoHandler : IHandler<ContatoRequest, ContatoResponse>
    {
        private readonly IContatoCriadoProducer _contatoProducer;
        private readonly INotificacaoContext _notificacaoContext;
        public InserirContatoHandler
        (
            IContatoCriadoProducer contatoProducer,
            INotificacaoContext notificacaoContext)
        {
            _contatoProducer = contatoProducer;
            _notificacaoContext = notificacaoContext;
        }

        public async Task<ContatoResponse> Handle(ContatoRequest request, CancellationToken cancellationToken)
        {

            var contato = new Contato(request.Nome, request.Email, new Domain.Shared.ValueObject.Telefone(request.Telefone?.Ddd, request.Telefone?.Numero));

            if (contato.Invalid)
            {
                _notificacaoContext.AddNotificacoes(contato.ValidationResult);
                return new ContatoResponse("", false, null);
            }

           await _contatoProducer.CriarContato(new Domain.Commands.ContatoCriadoCommand()
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

            return new ContatoResponse("Solicitação de inclusão de contato realizda com sucesso", true, new { contato.Id});
        }
    }
}
