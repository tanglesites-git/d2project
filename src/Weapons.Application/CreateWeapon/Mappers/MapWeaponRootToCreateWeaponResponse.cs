using Weapons.Domain.Weapon;

namespace Weapons.Application.CreateWeapon.Mappers;

public class MapWeaponRootToCreateWeaponResponse
{
    public static CreateWeaponResponse Map(WeaponRoot root)
    {
        return new CreateWeaponResponse
        {
            Name = root.Name,
            AmmoType = root.AmmoType,
            DisplayName = root.DisplayName,
            FlavorText = root.FlavorText,
            Hash = root.Hash,
            IconUrl = root.IconUrl,
            ScreenshotUrl = root.ScreenshotUrl,
            Source = root.Source,
            TierType = root.TierType,
            WatermarkUrl = root.WatermarkUrl,
            DamageTypeName = root.DamageTypeName,
            DamageTypeDescription = root.DamageTypeDescription,
            DamageTypeIconUrl = root.DamageTypeIconUrl,
            DamageTypeTransparentIconUrl = root.DamageTypeTransparentIconUrl,
        };
    }
}