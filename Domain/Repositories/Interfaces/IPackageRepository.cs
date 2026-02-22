using Domain.Models;

namespace Domain.Repositories.Interfaces;

/// <summary>
/// Defines a repository for accessing and managing Package entities.
/// </summary>
public interface IPackageRepository
{
    /// <summary>
    /// Retrieves an package by its id.
    /// </summary>
    /// <param name="id">Package id.</param>
    /// <returns>
    /// AUR package.
    /// </returns>
    Task<AurPackage?> GetPackageAsync(int id);

    /// <summary>
    /// Retrieves an package by its name.
    /// </summary>
    /// <param name="name">Package name.</param>
    /// <returns>
    /// AUR package.
    /// </returns>
    Task<AurPackage?> GetPackageAsync(string name);

    /// <summary>
    /// Retrieves all packages.
    /// </summary>
    /// <returns>
    /// List of packages.
    /// </returns>
    Task<List<AurPackage>> GetAllPackagesAsync();

    /// <summary>
    /// Adds a new package to the repository.
    /// </summary>
    /// <param name="package">Package to add.</param>
    void Add(AurPackage package);
}