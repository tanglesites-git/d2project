namespace Weapons.Domain.Weapon;

public class Lore
{
    public required Guid Id { get; set; }
    public required long Hash { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Subtitle { get; set; } = null!;
}