namespace Shared.Dtos;

public record AurPackageDto
(
    int ID, 
    string Name, 
    string? Version, 
    string? URL, 
    string? Description
);