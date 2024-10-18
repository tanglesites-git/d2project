namespace Weapons.Domain.Weapon;

public class DamageType
{
    public required Guid Id { get; set; }
    public required long Hash { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string IconUrl { get; set; }
    public required int Red { get; set; }
    public required int Green { get; set; }
    public required int Blue { get; set; }
    public required int Alpha { get; set; }
}