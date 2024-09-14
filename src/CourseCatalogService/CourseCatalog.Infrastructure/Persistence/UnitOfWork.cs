namespace CourseCatalog.Infrastructure.Persistence;

public class UnitOfWork(CatalogDbContext context) : IUnitOfWork
{
    public void BeginTransaction()
    {
        context.Database.BeginTransaction();
    }

    public async Task CommitTransactionAsync()
    {
        await context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await context.Database.RollbackTransactionAsync();
    }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}
