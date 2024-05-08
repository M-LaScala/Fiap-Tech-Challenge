namespace Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate
{
    public interface IContatoRepository
    {
        ValueTask<Guid> Inserir(Contato contato, CancellationToken cancellationToken);

        ValueTask Aualizar(Contato contato, CancellationToken cancellationToken);

        ValueTask<Contato> Delete(Guid? id, CancellationToken cancellationToken);

        ValueTask<Contato> ObterPorId(Guid? id);

        ValueTask<IEnumerable<Contato>> ObterPorDdd(string ddd);
    }
}
