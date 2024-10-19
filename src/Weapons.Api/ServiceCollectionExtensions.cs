using Microsoft.Extensions.Options;

namespace Weapons.Api;

public static class ServiceCollectionExtensions
{
    public static void AddConfiguration<TBindable>(this IServiceCollection services, IConfiguration configuration, string sectionName) where TBindable : class
    {
        services.Configure<TBindable>(configuration.GetSection(sectionName));
        services.AddSingleton(s => s.GetRequiredService<IOptions<TBindable>>().Value);
    }
}