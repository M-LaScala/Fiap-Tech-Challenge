namespace Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate
{
    public interface IContatoRepository
    {
        ValueTask<Guid> Inserir(Contato contato, CancellationToken cancellationToken = default);

        ValueTask Aualizar(Contato contato, CancellationToken cancellationToken = default);

        ValueTask<Contato> Delete(Guid? id, CancellationToken cancellationToken = default);

        ValueTask<Contato> ObterPorId(Guid? id);

        ValueTask<IEnumerable<Contato>> ObterPorDdd(string ddd);
    }
}
