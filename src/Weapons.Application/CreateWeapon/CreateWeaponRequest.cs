namespace Weapons.Application.CreateWeapon;

public class CreateWeaponRequest
{
    public CreateWeaponRequest(long hash, string name, string iconUrl, string watermarkUrl,
        string screenshotUrl, string displayName, string flavorText, string tierType, string ammoType, string source,
        string damageTypeName, string damageTypeDescription, string damageTypeIconUrl,
        string damageTypeTransparentIconUrl)
    {
        Hash = hash;
        Name = name;
        IconUrl = iconUrl;
        WatermarkUrl = watermarkUrl;
        ScreenshotUrl = screenshotUrl;
        DisplayName = displayName;
        FlavorText = flavorText;
        TierType = tierType;
        AmmoType = ammoType;
        Source = source;
        DamageTypeName = damageTypeName;
        DamageTypeDescription = damageTypeDescription;
        DamageTypeIconUrl = damageTypeIconUrl;
        DamageTypeTransparentIconUrl = damageTypeTransparentIconUrl;
    }

    public CreateWeaponRequest()
    {
    }
    
    public required long Hash { get; init; }
    public required string Name { get; init; }
    public required string IconUrl { get; init; }
    public required string WatermarkUrl { get; init; }
    public required string ScreenshotUrl { get; init; }
    public required string DisplayName { get; init; }
    public string FlavorText { get; init; } = null!;
    public required string TierType { get; init; }
    public required string AmmoType { get; init; }
    public string Source { get; init; } = null!;
    public required string DamageTypeName { get; set; }
    public required string DamageTypeDescription { get; init; } = null!;
    public required string DamageTypeIconUrl { get; init; } = null!;
    public required string DamageTypeTransparentIconUrl { get; init; } = null!;
}