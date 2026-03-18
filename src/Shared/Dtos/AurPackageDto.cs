namespace Shared.Dtos;

/// <summary>
/// Represents a dto containing parsed AUR package information.
/// </summary>
/// <param name="ID">Unique package identifier.</param>
/// <param name="Name">Package name</param>
/// <param name="Version">Package version. Null if not found.</param>
/// <param name="URL">Source URL of the package. Null if not found.</param>
/// <param name="Description">Package description. Null if not found.</param>
public record AurPackageDto
(
    int ID, 
    string Name, 
    string? Version, 
    string? URL, 
    string? Description
);