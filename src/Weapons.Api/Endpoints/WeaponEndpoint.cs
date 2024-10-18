using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Weapons.Application.WeaponFeature;
using Weapons.Application.WeaponFeature.EntityMappers;

namespace Weapons.Api.Endpoints;

public static class WeaponEndpoint
{
    public static WebApplication AddWeaponEndpoint(this WebApplication app)
    {
        app.MapPost("/weapon", HandleCreateWeapon).WithName(nameof(HandleCreateWeapon));
        return app;
    }

    private static async Task<IResult> HandleCreateWeapon(IMediator mediator, CreateWeaponRequest request)
    {
        var command = MappingProfiles.MapCreateWeaponRequestToWeaponCommand(request);
        var result = await mediator.Send(command);
        return result.ToResultCreated(nameof(HandleCreateWeapon), new { Id = command.Hash }, command);

    }
}

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
}