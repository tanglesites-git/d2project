using Dapper;
using Microsoft.AspNetCore.Http;
using Weapons.Application;
using Weapons.Application.Contexts;
using Weapons.Application.GetAllWeapons;
using Weapons.Application.Interfaces;
using Weapons.Domain.Weapon;

namespace Weapons.Infrastructure;

public class WeaponRepository : IWeaponRepository
{
    private readonly ISQLiteConnectionFactory _factory;

    public WeaponRepository(ISQLiteConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<(IEnumerable<WeaponRoot>, int)> GetAllWeaponsAsync(int page, int pageSize, int offset)
    {
        var conn = await _factory.GetConnectionAsync();

        var multiResponse = await conn.QueryMultipleAsync(QueryGateway.GetAllWeapons, new { Limit = pageSize, Offset = (int)offset! });
        var rows = await multiResponse.ReadAsync<WeaponRoot>();
        var totalRows = await multiResponse.ReadSingleAsync<int>();
        return (rows, totalRows);
    }

    public Task Create(WeaponRoot weapon)
    {
        throw new NotImplementedException();
    }
}