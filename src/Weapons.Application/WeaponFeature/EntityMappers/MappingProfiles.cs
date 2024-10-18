using Weapons.Domain.Weapon;

namespace Weapons.Application.WeaponFeature.EntityMappers;

public class MappingProfiles
{
    public static WeaponCommand MapCreateWeaponRequestToWeaponCommand(CreateWeaponRequest request)
    {
        return new WeaponCommand
        {
            Name = request.Name,
            AmmoType = request.AmmoType,
            DisplayName = request.DisplayName,
            FlavorText = request.FlavorText,
            Hash = request.Hash,
            IconUrl = request.IconUrl,
            ScreenshotUrl = request.ScreenshotUrl,
            Source = request.Source,
            TierType = request.TierType,
            WatermarkUrl = request.WatermarkUrl,
            DamageTypeName = request.DamageTypeName,
            DamageTypeDescription = request.DamageTypeDescription,
            DamageTypeIconUrl = request.DamageTypeIconUrl,
            DamageTypeTransparentIconUrl = request.DamageTypeTransparentIconUrl,
        };
    }

    public static WeaponRoot MapWeaponCommandToWeaponRoot(WeaponCommand command)
    {
        return new WeaponRoot
        {
            Id = Guid.NewGuid(),
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

    public static WeaponResponse MapWeaponRootToWeaponResponse(WeaponRoot root)
    {
        return new WeaponResponse
        {
            Id = root.Id,
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