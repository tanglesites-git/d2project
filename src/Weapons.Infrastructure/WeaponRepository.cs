using System.Diagnostics;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Weapons.Application;
using Weapons.Application.Contexts;
using Weapons.Application.GetAllWeapons;
using Weapons.Application.Interfaces;
using Weapons.Domain.Weapon;
using Weapons.Kernal.Logging;

namespace Weapons.Infrastructure;

public class WeaponRepository : IWeaponRepository
{
    private readonly ISQLiteConnectionFactory _factory;
    private readonly ILogger<WeaponRepository> _logger;

    public WeaponRepository(ISQLiteConnectionFactory factory, ILogger<WeaponRepository> logger)
    {
        _factory = factory;
        _logger = logger;
    }

    public async Task<(IEnumerable<WeaponRoot>, int)> GetAllWeaponsAsync(int page, int pageSize, int offset)
    {
        var conn = await _factory.GetConnectionAsync();
        var start = Stopwatch.GetTimestamp();
        var multiResponse = await conn.QueryMultipleAsync(QueryGateway.GetAllWeapons, new { Limit = pageSize, Offset = (int)offset! });
        var end = Stopwatch.GetElapsedTime(start);
        WeaponRepositoryLoggers.LogQuery(_logger, QueryGateway.GetAllWeapons, end * 1000);
        var rows = await multiResponse.ReadAsync<WeaponRoot>();
        var totalRows = await multiResponse.ReadSingleAsync<int>();
        return (rows, totalRows);
    }

    public Task Create(WeaponRoot weapon)
    {
        throw new NotImplementedException();
    }
}