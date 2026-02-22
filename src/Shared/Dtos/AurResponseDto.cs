namespace Shared.Dtos; 

/// <summary>
/// Represents a dto containing list of packages received from the AUR API response.
/// </summary>
/// <param name="Packages">List of packages</param>
public record AurResponseDto
(
    List<AurPackageDto> Packages
);