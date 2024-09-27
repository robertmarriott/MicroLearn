namespace CourseCatalog.Contracts.Common.Dtos;

public class PaginatedListDto<T>(
    IEnumerable<T> items,
    int totalCount,
    int pageNumber,
    int pageSize)
{
    public IReadOnlyList<T> Items { get; } = items.ToList();
    public int TotalCount { get; } = totalCount;
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
    public int TotalPages { get; } = (int)Math.Ceiling(totalCount / (double)pageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}
