namespace Infrastructure.AUR.Models;

/// <summary>
/// Represents a raw package from AUR API response.
/// </summary>
public class AurPackageRaw
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string? Version { get; set; } = null!;
    public string? URL { get; set; } = null!;
    public string? Description { get; set; } = null!;
}