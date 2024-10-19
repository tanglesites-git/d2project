using Microsoft.Extensions.DependencyInjection;
using Weapons.Application.Contexts;
using Weapons.Application.Interfaces;

namespace Weapons.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        
        services.AddTransient<IWeaponRepository, WeaponRepository>();
        return services;
    }

    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<ISQLiteConnectionFactory>(_ => new SQLiteConnectionFactory(connectionString));
        return services;
    }
}