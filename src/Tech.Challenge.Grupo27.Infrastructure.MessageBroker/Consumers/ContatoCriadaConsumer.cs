using MassTransit;
using Tech.Challenge.Grupo27.Application.Worker.InserirContato.Dispatchers;
using Tech.Challenge.Grupo27.Domain.Commands;

namespace Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Consumers
{
    public class ContatoCriadaConsumer : IConsumer<ContatoCriadoCommand>
    {
        private readonly InserirContatoDispatcher _contato;

        public ContatoCriadaConsumer(InserirContatoDispatcher contato)
        {
            _contato = contato;
        }

        public async Task Consume(ConsumeContext<ContatoCriadoCommand> context)
        {
            await _contato.Handle(context?.Message, CancellationToken.None);
        }
    }
}
