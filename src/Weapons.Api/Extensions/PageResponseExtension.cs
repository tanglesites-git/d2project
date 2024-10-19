namespace Weapons.Api.Extensions;

internal class PageResponseExtension<TResponse> where TResponse : class
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Count { get; set; }
    public int TotalPages { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }
    public IEnumerable<TResponse>? Data { get; set; }
}