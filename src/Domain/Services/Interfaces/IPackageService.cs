using Shared.Dtos;

namespace Domain.Services.Interfaces;

/// <summary>
/// Defines domain-level operations for working with packages.
/// </summary>
public interface IPackageService
{
    /// <summary>
    /// Retrieves an package by its id.
    /// </summary>
    /// <param name="id">Package id.</param>
    /// <returns>
    /// AUR package data.
    /// </returns>
    Task<AurPackageDto> GetPackageAsync(int id);

    /// <summary>
    /// Retrieves an package by its name.
    /// </summary>
    /// <param name="name">Package name.</param>
    /// <returns>
    /// AUR package data.
    /// </returns>
    Task<AurPackageDto> GetPackageAsync(string name);

    /// <summary>
    /// Retrieves all packages.
    /// </summary>
    /// <returns>
    /// List of packages data.
    /// </returns>
    Task<List<AurPackageDto>> GetAllPackagesAsync();

    /// <summary>
    /// Adds a new package.
    /// </summary>
    /// <param name="packageDto">Package data to add.</param>
    Task AddAsync(AurPackageDto packageDto);

    /// <summary>
    /// Adds a new packages.
    /// </summary>
    /// <param name="packDtos">Packages data to add.</param>
    Task AddPackages(IEnumerable<AurPackageDto> packDtos);
}