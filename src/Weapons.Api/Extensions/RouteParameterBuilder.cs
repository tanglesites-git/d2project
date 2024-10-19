using Microsoft.AspNetCore.WebUtilities;

namespace Weapons.Api.Extensions;

public class RouteParameterBuilder
{
    public static string CreatePaginatedParameters(HttpContext context, int? nextPage, int? pageSize)
    {
        var request = context.Request;
        var urlBuilder = new UriBuilder
        {
            Scheme = request.Scheme,
            Host = request.Host.Host,
            Path = request.Path,
            Port = request.Host.Port ?? (request.IsHttps ? 443 : 80)
        };

        var query = QueryHelpers.ParseQuery(request.QueryString.Value);
        var dict = query
            .SelectMany(
                x =>
                    x.Value, (col, value) =>
                    new KeyValuePair<string, string>(col.Key, value!));
        var queryParams = new Dictionary<string, string>(dict);

        if (nextPage.HasValue)
        {
            queryParams["page"] = nextPage.ToString()!;
        }

        if (pageSize.HasValue)
        {
            queryParams["pageSize"] = pageSize.ToString()!;
        }
        
        var queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        urlBuilder.Query = queryString;
        
        return urlBuilder.ToString();
    }
}