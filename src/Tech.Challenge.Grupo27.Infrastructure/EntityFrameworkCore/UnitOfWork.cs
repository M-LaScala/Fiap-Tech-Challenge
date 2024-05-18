using Microsoft.EntityFrameworkCore.Storage;
using Tech.Challenge.Grupo27.Domain.Shared;

namespace Tech.Challenge.Grupo27.Infrastructure.EntityFrameworkCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechChallengeGrupo27Context _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(TechChallengeGrupo27Context context)
        {
            _context = context;
        }

        public virtual async Task BeginTransaction(CancellationToken cancellationToken = default)
        {
            if (_transaction is null)
                _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public Task CommitTransaction(CancellationToken cancellationToken = default)
        {
            return _transaction.CommitAsync(cancellationToken);
        }

        public Task SaveChanges(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void DetectChanges()
        {
            _context.ChangeTracker.DetectChanges();
        }

        public void DisableAutoDetectChanges()
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
