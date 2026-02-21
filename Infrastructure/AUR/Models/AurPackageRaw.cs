namespace Infrastructure.AUR.Models;

public class AurPackageRaw
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string? Version { get; set; } = null!;
    public string? URL { get; set; } = null!;
    public string? Description { get; set; } = null!;
}