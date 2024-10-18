using Weapons.Domain.Weapon;

namespace Weapons.Application.WeaponFeature;

public interface IWeaponRepository
{
    Task Create(WeaponRoot weapon);
}