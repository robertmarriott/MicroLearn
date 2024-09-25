namespace SharedKernel.Domain;

public interface IUnitOfWork
{
    void BeginTransaction();

    Task CommitTransactionAsync();

    Task RollbackTransactionAsync();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
