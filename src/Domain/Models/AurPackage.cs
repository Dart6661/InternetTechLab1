namespace Domain.Models;

/// <summary>
/// Represents a AUR package in the domain layer.
/// </summary>
/// <param name="ID">Unique package identifier.</param>
/// <param name="name">Package name.</param>
/// <param name="version">Package version at time of request.</param>
/// <param name="URL">Source URL of the package.</param>
/// <param name="description">Package description.</param>
public class AurPackage(int ID, string name, string? version, string? URL, string? description)
{
    public int ID { get; } = ID;
    public string Name { get; } = name;
    public string? Version { get; } = version;
    public string? URL { get; } = URL;
    public string? Description { get; } = description;
}