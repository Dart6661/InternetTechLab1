using Infrastructure.AUR.Models;
using Shared.Dtos;

namespace Infrastructure.AUR.Mapping;

/// <summary>
/// Provides mapping methods to convert between raw AUR packages and AUR package dtos.
/// </summary>
public static class AurPackageRawMapper
{
    /// <summary>
    /// Converts AurPackageRaw to AurPackageDto.
    /// </summary>
    /// <param name="package">Raw AUR package to convert.</param>
    /// <returns>
    /// AurPackageDto.
    /// </returns>
    public static AurPackageDto? GetDto(AurPackageRaw package) => 
        IsValid(package) 
        ? new AurPackageDto(package.ID, package.Name, package.Version, package.URL, package.Description) 
        : null;

    /// <summary>
    /// Converts AurPackageDto to AurPackageRaw.
    /// </summary>
    /// <param name="dto">AUR package dto to convert.</param>
    /// <returns>
    /// AurPackageRaw.
    /// </returns>
    public static AurPackageRaw GetAurPackage(AurPackageDto dto) => new() 
    { 
        ID = dto.ID, 
        Name = dto.Name, 
        Version = dto.Version, 
        URL = dto.URL, 
        Description = dto.Description 
    };

    /// <summary>
    /// Checks the validity of the raw AUR package.
    /// </summary>
    /// <param name="package">Validation package.</param>
    /// <returns>
    /// True if the package name is not empty, otherwise, false.
    /// </returns>
    public static bool IsValid(AurPackageRaw package) => !string.IsNullOrWhiteSpace(package.Name);
}