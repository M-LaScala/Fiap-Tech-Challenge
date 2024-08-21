using MassTransit;
using Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker;
using Tech.Challenge.Grupo27.Domain.Commands;

namespace Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Producers
{
    public class ContatoCriadoProducer : IContatoCriadoProducer
    {
        private readonly IBusControl _bus;

        public ContatoCriadoProducer(IBusControl bus)
        {
            _bus = bus;
        }

        public Task CriarContato(ContatoCriadoCommand mensagem)
        {
            return _bus.Send(mensagem);
        }
    }
}
