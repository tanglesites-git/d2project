using FluentValidation;
using MediatR;
using Weapons.Api.Extensions;
using Weapons.Application.GetAllWeapons;
using Weapons.Application.GetAllWeapons.Mappers;
using Weapons.Domain.Weapon;
using RouteParameterBuilder = Weapons.Infrastructure.RouteParameterBuilder;

namespace Weapons.Api.Endpoints;

public static class GetAllWeaponsEndpoint
{
    public static WebApplication AddGetAllWeapons(this WebApplication app)
    {
        app.MapGet("/weapons", HandleGetAllWeapons).WithName(nameof(HandleGetAllWeapons));
        return app;
    }

    private static async Task<IResult> HandleGetAllWeapons(HttpContext context, IMediator mediator,
        [AsParameters] PageRequest pageRequest)
    {
        var query = MapPageRequestToPageGetAllWeaponsQuery.Map(pageRequest);
        var result = await mediator.Send(query);
        return result.ToOkResponse(nameof(HandleGetAllWeapons), context);
    }
}