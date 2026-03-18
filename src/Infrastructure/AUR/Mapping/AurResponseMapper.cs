using Infrastructure.AUR.Models;
using Shared.Dtos;

namespace Infrastructure.AUR.Mapping;

/// <summary>
/// Provides mapping methods to convert between AUR responses and AUR response dtos.
/// </summary>
public static class AurResponseMapper
{
    /// <summary>
    /// Converts AurResponse to AurResponseDto.
    /// </summary>
    /// <param name="response">AurResponse to convert.</param>
    /// <returns>
    /// AurResponseDto.
    /// </returns>
    public static AurResponseDto GetDto(AurResponse response) => new
    (
        [.. response.Packages
            .Select(AurPackageRawMapper.GetDto)
            .OfType<AurPackageDto>()]
    );
}