using MassTransit;
using Tech.Challenge.Grupo27.Application.Worker.DeleteContato.Dispatchers_;
using Tech.Challenge.Grupo27.Domain.Commands;

namespace Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Consumers
{
    public class ContatoDeletadoConsumer : IConsumer<ContatoDeletadoCommand>
    {
        private readonly IDeletarContatoDispatcher _contato;

        public ContatoDeletadoConsumer(IDeletarContatoDispatcher contato)
        {
            _contato = contato;
        }
        public async Task Consume(ConsumeContext<ContatoDeletadoCommand> context)
        {
            await _contato.DeletarContatoAsync(context?.Message, CancellationToken.None);
        }
    }
}
