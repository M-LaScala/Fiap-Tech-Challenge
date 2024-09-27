using MassTransit;
using Tech.Challenge.Grupo27.Domain.Commands;
using Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker;

namespace Tech.Challenge.Grupo27.Infrastructure.MessageBroker.Producers
{
    public class ContatoDeletadoProducer : IContatoDeletadoProducer
    {
        private readonly IBusControl _bus;

        public ContatoDeletadoProducer(IBusControl bus)
        {
            _bus = bus;
        }

        public Task DeleteContato(ContatoDeletadoCommand mensagem)
        {
            return _bus.Send(mensagem);
        }
    }
}
