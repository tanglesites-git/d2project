using Weapons.Domain.Weapon;

namespace Weapons.Application.GetAllWeapons.Mappers;

public static class MapWeaponRootToGetAllWeaponsResponse
{
    public static GetAllWeaponsResponse Map(WeaponRoot root)
    {
        return new GetAllWeaponsResponse
        {
            Id = root.Id,
            Name = root.Name,
            Hash = root.Hash,
            IconUrl = root.IconUrl,
            WatermarkUrl = root.WatermarkUrl,
            ScreenshotUrl = root.ScreenshotUrl,
            DisplayName = root.DisplayName,
            FlavorText = root.FlavorText,
            TierType = root.TierType,
            AmmoType = root.AmmoType,
            Source = root.Source,
            DamageTypeName = root.DamageTypeName,
            DamageTypeIconUrl = root.DamageTypeIconUrl,
            DamageTypeDescription = root.DamageTypeDescription,
            DamageTypeTransparentIconUrl = root.DamageTypeTransparentIconUrl,
        };
    }
}