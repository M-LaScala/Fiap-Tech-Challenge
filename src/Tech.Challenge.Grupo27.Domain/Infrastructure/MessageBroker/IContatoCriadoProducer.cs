using Tech.Challenge.Grupo27.Domain.Commands;

namespace Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker
{
    public interface IContatoCriadoProducer
    {
        Task CriarContato(ContatoCriadoCommand mensagem);
    }
}
