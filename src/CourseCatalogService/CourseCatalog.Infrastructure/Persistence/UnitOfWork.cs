namespace CourseCatalog.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    public void BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public Task CommitTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public Task RollbackTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
