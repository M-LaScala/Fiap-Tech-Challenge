using MassTransit;
using Tech.Challenge.Grupo27.Application.Worker.AtualizarContato.Dispatchers_;
using Tech.Challenge.Grupo27.Domain.Commands;

namespace Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Consumers
{
    public class ContatoAtualizadoConsumer : IConsumer<ContatoAtualizadoCommand>
    {
        private readonly IAtualizarContatoDispatcher _contato;

        public ContatoAtualizadoConsumer(IAtualizarContatoDispatcher contato)
        {
            _contato = contato;
        }

        public async Task Consume(ConsumeContext<ContatoAtualizadoCommand> context)
        {
            await _contato.AtualizarContatoAsync(context?.Message, CancellationToken.None);
        }
    }
}
