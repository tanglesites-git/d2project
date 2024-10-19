using FluentValidation;
using LanguageExt.Common;
using Weapons.Api.Endpoints;
using Weapons.Application.GetAllWeapons;
using Weapons.Domain.Weapon;

namespace Weapons.Api.Extensions;

public static class ResultsExtensions
{
    public static IResult ToResultCreated<TResult, TContract>(this Result<TResult> result, string route, object obj, TContract entity) where TResult : class where TContract : class
    {
        return result.Match(
            m => Results.CreatedAtRoute(route, obj, entity),
            err =>
            {
                if (err is ValidationException validationException)
                {
                    return Results.BadRequest(new { Route=route, StatusCode = 400, Errors = validationException.Errors.Select(x => new { Property = x.PropertyName, Error = x.ErrorMessage, Code = x.ErrorCode }) });
                }
                return Results.StatusCode(500);
            }
        );
    }

    public static IResult ToOkResponse<TContract>(this Result<PagedResponse<TContract>> result, string route, HttpContext context) 
        where TContract : class
    {
        return result.Match<IResult>(
            m =>
            {
                var nextPage = (m.Page < m.TotalPages) ? m.Page + 1 : (int?)null;
                var previousPage = (m.Page <= 1) ? (int?)null : m.Page - 1;
                var response = new PageResponseExtension<TContract>
                {
                    Page = m.Page,
                    PageSize = m.PageSize,
                    Count = m.Count,
                    TotalPages = m.TotalPages,
                    Data = m.Data,
                    Next = nextPage.HasValue ? RouteParameterBuilder.CreatePaginatedParameters(context, nextPage, m.PageSize) : null,
                    Previous = previousPage.HasValue ? RouteParameterBuilder.CreatePaginatedParameters(context, previousPage, m.PageSize) : null,
                };
                return Results.Ok(response);
            },
            err =>
            {
                if (err is ValidationException validationException)
                {
                    return Results.BadRequest(new
                    {
                        Route = route, StatusCode = 400,
                        Errors = validationException.Errors.Select(x => new
                            { Property = x.PropertyName, Error = x.ErrorMessage, Code = x.ErrorCode })
                    });
                }
                return Results.StatusCode(500);
            }
        );
    }
}