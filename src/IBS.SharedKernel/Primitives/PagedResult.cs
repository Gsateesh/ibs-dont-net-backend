namespace IBS.SharedKernel.Primitives;

/// <summary>
/// A single page of results plus the paging metadata the UI needs to render a pager.
/// </summary>
/// <typeparam name="T">Item type.</typeparam>
public sealed class PagedResult<T>
{
    public PagedResult() { }

    public PagedResult(IReadOnlyList<T> items, int page, int pageSize, int totalCount)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    /// <summary>The items on this page.</summary>
    public IReadOnlyList<T> Items { get; set; } = [];

    /// <summary>1-based page number.</summary>
    public int Page { get; set; } = 1;

    /// <summary>Number of items requested per page.</summary>
    public int PageSize { get; set; } = 25;

    /// <summary>Total number of items matching the filter, across all pages.</summary>
    public int TotalCount { get; set; }

    /// <summary>Total number of pages available for the current page size.</summary>
    public int TotalPages => PageSize <= 0 ? 0 : (int)Math.Ceiling(TotalCount / (double)PageSize);

    /// <summary>True when a further page exists.</summary>
    public bool HasNextPage => Page < TotalPages;

    /// <summary>True when a previous page exists.</summary>
    public bool HasPreviousPage => Page > 1;
}
