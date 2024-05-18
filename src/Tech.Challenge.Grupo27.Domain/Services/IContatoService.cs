using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Shared.ValueObject;

namespace Tech.Challenge.Grupo27.Domain.Services
{
    public interface IContatoService
    {
        ValueTask<Guid> Inserir(Contato contato, CancellationToken cancellationToken);

        ValueTask Atualizar(Contato contato, CancellationToken cancellationToken);

        ValueTask<Contato?> Delete(Guid? id, CancellationToken cancellationToken);

        ValueTask<Contato?> ObterPorId(Guid? id);

        ValueTask<IEnumerable<Contato>> ObterPorDdd(string? ddd);
    }
}
