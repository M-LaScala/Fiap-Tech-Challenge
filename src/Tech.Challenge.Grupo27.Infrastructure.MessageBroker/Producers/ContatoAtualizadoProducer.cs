using MassTransit;
using Tech.Challenge.Grupo27.Domain.Commands;
using Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker;

namespace Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Producers
{
    public class ContatoAtualizadoProducer : IContatoAtualizadoProducer
    {
        private readonly IBusControl _bus;

        public ContatoAtualizadoProducer(IBusControl bus)
        {
            _bus = bus;
        }

        public Task AtualizarContato(ContatoAtualizadoCommand mensagem)
        {
            return _bus.Send(mensagem);
        }
    }
}
