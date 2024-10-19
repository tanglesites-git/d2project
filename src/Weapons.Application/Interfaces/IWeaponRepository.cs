using Microsoft.AspNetCore.Http;
using Weapons.Application.GetAllWeapons;
using Weapons.Domain.Weapon;

namespace Weapons.Application.Interfaces;

public interface IWeaponRepository
{
    Task<(IEnumerable<WeaponRoot>, int)> GetAllWeaponsAsync(int page, int pageSize, int offset);
    Task Create(WeaponRoot weapon);
}