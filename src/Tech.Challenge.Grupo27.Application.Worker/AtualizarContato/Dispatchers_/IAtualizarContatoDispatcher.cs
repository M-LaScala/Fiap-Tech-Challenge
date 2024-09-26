using Tech.Challenge.Grupo27.Domain.Commands;

namespace Tech.Challenge.Grupo27.Application.Worker.AtualizarContato.Dispatchers_
{
    public interface IAtualizarContatoDispatcher
    {
        Task AtualizarContatoAsync(ContatoAtualizadoCommand request, CancellationToken cancellationToken);
    }
}
