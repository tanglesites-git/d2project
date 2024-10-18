using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Weapons.Application.WeaponFeature;
using Weapons.Domain.Weapon;

namespace Weapons.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IWeaponRepository, WeaponRepository>();
        
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        return services;
    }
}