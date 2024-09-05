using Tech.Challenge.Grupo27.Domain.Commands;

namespace Tech.Challenge.Grupo27.Application.Worker.InserirContato.Dispatchers_
{
    public interface IInserirContatoDispatcher
    {
        Task InseirContatoAsync(ContatoCriadoCommand request, CancellationToken cancellationToken);
    }
}
