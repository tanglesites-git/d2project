namespace Weapons.Application.CreateWeapon.Mappers;

public class MapCreateWeaponRequestToCreateWeaponCommand
{
    public static CreateWeaponCommand Map(CreateWeaponRequest request)
    {
        return new CreateWeaponCommand
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
}