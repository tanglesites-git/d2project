using LanguageExt.Common;
using Weapons.Domain.Weapon;

namespace Weapons.Application.WeaponFeature;

public class WeaponRepository : IWeaponRepository
{
    private readonly List<WeaponRoot> _weapons = new();


    public Task Create(WeaponRoot weapon)
    {
        if (_weapons.Contains(weapon))
        {
            return Task.CompletedTask;
        }

        _weapons.Add(weapon);
        return Task.CompletedTask;
    }
}