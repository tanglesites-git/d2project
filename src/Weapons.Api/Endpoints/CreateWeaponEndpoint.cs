using MediatR;
using Weapons.Api.Extensions;
using Weapons.Application.CreateWeapon;
using Weapons.Application.CreateWeapon.Mappers;

namespace Weapons.Api.Endpoints;

public static class CreateWeaponEndpoint
{
    public static WebApplication AddCreateWeaponEndpoint(this WebApplication app)
    {
        app.MapPost("/weapon", HandleCreateWeapon).WithName(nameof(HandleCreateWeapon));
        return app;
    }

    private static async Task<IResult> HandleCreateWeapon(IMediator mediator, CreateWeaponRequest request)
    {
        var command = MapCreateWeaponRequestToCreateWeaponCommand.Map(request);
        var result = await mediator.Send(command);
        return result.ToResultCreated(nameof(HandleCreateWeapon), new { Id = command.Hash }, command);

    }
}