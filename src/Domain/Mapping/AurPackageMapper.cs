using Domain.Models;
using Shared.Dtos;

namespace Domain.Mapping;

/// <summary>
/// Provides mapping methods to convert between AUR package domain objects and AUR package dtos.
/// </summary>
public static class AurPackageMapper
{
    /// <summary>
    /// Converts AurPackage to AurPackageDto.
    /// </summary>
    /// <param name="package">AurPackage to convert.</param>
    /// <returns>
    /// AUR package dto.
    /// </returns>
    public static AurPackageDto GetDto(AurPackage package) => new(package.ID, package.Name, package.Version, package.URL, package.Description);

    /// <summary>
    /// Converts AurPackageDto to AurPackage.
    /// </summary>
    /// <param name="dto">AurPackageDto to convert.</param>
    /// <returns>
    /// AUR package.
    /// </returns>
    public static AurPackage GetAurPackage(AurPackageDto dto) => new(dto.ID, dto.Name, dto.Version, dto.URL, dto.Description);
}