using Weapons.Domain.Weapon;

namespace Weapons.Application.CreateWeapon.Mappers;

public class MapCreateWeaponCommandToWeaponRoot
{
    public static WeaponRoot Map(CreateWeaponCommand command)
    {
        return new WeaponRoot
        {
            Name = command.Name,
            AmmoType = command.AmmoType,
            DisplayName = command.DisplayName,
            FlavorText = command.FlavorText,
            Hash = command.Hash,
            IconUrl = command.IconUrl,
            ScreenshotUrl = command.ScreenshotUrl,
            Source = command.Source,
            TierType = command.TierType,
            WatermarkUrl = command.WatermarkUrl,
            DamageTypeName = command.DamageTypeName,
            DamageTypeDescription = command.DamageTypeDescription,
            DamageTypeIconUrl = command.DamageTypeIconUrl,
            DamageTypeTransparentIconUrl = command.DamageTypeTransparentIconUrl,
        };
    }
}