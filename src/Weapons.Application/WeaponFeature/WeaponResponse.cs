using MediatR;

namespace Weapons.Application.WeaponFeature;

public record WeaponResponse : IRequest
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
}