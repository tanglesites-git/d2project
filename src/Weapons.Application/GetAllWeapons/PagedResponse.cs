namespace Weapons.Application.GetAllWeapons;


public class Paged
{
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int Count { get; init; }
    public int TotalPages { get; init; }

    protected Paged()
    {
        PageSize = 10;
    }

    public Paged(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }
}

public class PagedResponse<TResponse> : Paged
{
    public IEnumerable<TResponse>? Data { get; init; }
}