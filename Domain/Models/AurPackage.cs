namespace Domain.Models;

public class AurPackage(int ID, string name, string? version, string? URL, string? description)
{
    public int ID { get; } = ID;
    public string Name { get; } = name;
    public string? Version { get; } = version;
    public string? URL { get; } = URL;
    public string? Description { get; } = description;
}