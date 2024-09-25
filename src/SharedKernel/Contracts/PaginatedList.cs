namespace SharedKernel.Contracts;

public class PaginatedList<TEntity>(
    IReadOnlyList<TEntity> items,
    int totalCount,
    int pageNumber,
    int pageSize) where TEntity : class
{
    public IReadOnlyList<TEntity> Items { get; } = items;
    public int TotalCount { get; } = totalCount;
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
    public int TotalPages { get; } = (int)Math.Ceiling(totalCount / (double)pageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}
