using Tech.Challenge.Grupo27.Domain.Commands;

namespace Tech.Challenge.Grupo27.Application.Worker.DeleteContato.Dispatchers_
{
    public interface IDeletarContatoDispatcher
    {
        Task DeletarContatoAsync(ContatoDeletadoCommand request, CancellationToken cancellationToken);
    }
}
