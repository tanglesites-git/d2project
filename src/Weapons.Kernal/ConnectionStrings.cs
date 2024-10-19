namespace Weapons.Kernal;

public class ConnectionStrings
{
    public const string SectionName = nameof(ConnectionStrings);
    public string? SQLiteConnection { get; set; }
}