using MassTransit;
using Tech.Challenge.Grupo27.Application.Worker.InserirContato.Dispatchers_;
using Tech.Challenge.Grupo27.Domain.Commands;

namespace Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Consumers
{
    public class ContatoCriadaConsumer : IConsumer<ContatoCriadoCommand>
    {
        private readonly IInserirContatoDispatcher _contato;

        public ContatoCriadaConsumer(IInserirContatoDispatcher contato)
        {
            _contato = contato;
        }

        public async Task Consume(ConsumeContext<ContatoCriadoCommand> context)
        {
            await _contato.InseirContatoAsync(context?.Message, CancellationToken.None);
        }
    }
}
