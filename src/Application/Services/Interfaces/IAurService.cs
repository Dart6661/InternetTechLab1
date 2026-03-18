using Shared.Dtos;

namespace Application.Services.Interfaces;

/// <summary>
/// Defines application-level operations for working with AUR packages.
/// </summary>
public interface IAurService
{
    /// <summary>
    /// Searches for packages in AUR and save it.
    /// </summary>
    /// <param name="name">Package name.</param>
    /// <returns>
    /// AUR package data.
    /// </returns>
    Task<List<AurPackageDto>> FindPackageAsync(string name);

    /// <summary>
    /// Retrieves an package by its id.
    /// </summary>
    /// <param name="id">Package id</param>
    /// <returns>
    /// AUR package data.
    /// </returns>
    Task<AurPackageDto> GetPackageAsync(int id);

    /// <summary>
    /// Retrieves an package by its name.
    /// </summary>
    /// <param name="name">Package name</param>
    /// <returns>
    /// AUR package data.
    /// </returns>
    Task<AurPackageDto> GetPackageAsync(string name);

    /// <summary>
    /// Retrieves all packages.
    /// </summary>
    /// <returns>
    /// List of packages.
    /// </returns>
    Task<List<AurPackageDto>> GetAllPackagesAsync();
}