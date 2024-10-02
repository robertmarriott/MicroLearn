namespace CourseCatalog.Contracts.Common.Responses;

public class PaginatedResponse<TResponse>(
    IEnumerable<TResponse> items,
    int pageNumber,
    int pageSize,
    int totalCount)
{
    public IReadOnlyList<TResponse> Items { get; } = items.ToList();
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
    public int TotalCount { get; } = totalCount;
    public int TotalPages { get; } = (int)Math.Ceiling(totalCount / (double)pageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}
