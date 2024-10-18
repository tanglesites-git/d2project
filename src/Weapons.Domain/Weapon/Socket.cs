using System.Collections.ObjectModel;

namespace Weapons.Domain.Weapon;

public class Socket
{
    public required Guid Id { get; set; }
    public required long Hash { get; set; }
    public required string Name { get; set; }
    public required string IconUrl { get; set; }
    public required string DisplayName { get; set; }
    public required string TierType { get; set; }
    public Collection<Stats> Stats { get; set; } = new Collection<Stats>();
}