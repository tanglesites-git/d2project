using System.Collections.ObjectModel;

namespace Weapons.Domain.Weapon;

public class WeaponRoot
{
    public required Guid Id { get; init; }
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
    // public required EquipmentSlotType EquipmentSlotType { get; set; }
    // public Collection<Stats> Stats { get; set; } = new Collection<Stats>();
    // public Lore? Lore { get; set; }
    // public DamageType DamageType { get; set; } = null!;
    // public Collection<Socket> Sockets { get; set; } = new Collection<Socket>();

    public string ReduceUrl(string type)
    {
        return Environment.OSVersion.Platform == PlatformID.Unix 
            ? $@"./{type}/{Name}.{IconUrl.Split('.').Last()}" 
            : $@".\{type}\{Name}.{IconUrl.Split('.').Last()}";
    }
}