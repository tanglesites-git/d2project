namespace Weapons.Domain.Weapon;

public class Stats
{
    public required Guid Id { get; set; }
    public required long Hash { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int Value { get; set; }
}