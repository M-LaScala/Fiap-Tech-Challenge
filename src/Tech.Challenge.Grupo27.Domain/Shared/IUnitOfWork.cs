namespace Tech.Challenge.Grupo27.Domain.Shared
{
    public interface IUnitOfWork
    {
        Task BeginTransaction(CancellationToken cancellationToken = default);
        Task CommitTransaction(CancellationToken cancellationToken = default);
        Task SaveChanges(CancellationToken cancellationToken = default);
        void DetectChanges();

        void DisableAutoDetectChanges();

    }
}
