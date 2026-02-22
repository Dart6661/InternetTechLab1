using Domain.Services.Interfaces;
using Domain.Services.Exceptions;
using Domain.Repositories.Interfaces;
using Domain.Mapping;
using Domain.Models;
using Shared.Dtos;

namespace Domain.Services;

/// <summary>
/// Service for working with packages.
/// </summary>
/// <param name="packRepos">Package repository.</param>
public class PackageService(IPackageRepository packRepos) : IPackageService
{
    private readonly IPackageRepository _packRepos = packRepos;

    /// <summary>
    /// Retrieves an package by its id.
    /// </summary>
    /// <param name="id">Package id.</param>
    /// <returns>
    /// AUR package data.
    /// </returns>
    /// <exception cref="PackageNotFoundException">Thrown when package cannot be found.</exception>
    public async Task<AurPackageDto> GetPackageAsync(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        AurPackage package = await _packRepos.GetPackageAsync(id) ?? throw new PackageNotFoundException($"package with id {id} not found");
        return AurPackageMapper.GetDto(package);
    }
    
    /// <summary>
    /// Retrieves an package by its name.
    /// </summary>
    /// <param name="name">Package name</param>
    /// <returns>
    /// AUR package data.
    /// </returns>
    /// <exception cref="PackageNotFoundException">Thrown when package cannot be found.</exception>
    public async Task<AurPackageDto> GetPackageAsync(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        AurPackage package = await _packRepos.GetPackageAsync(name) ?? throw new PackageNotFoundException($"package with name {name} not found");
        return AurPackageMapper.GetDto(package);
    }

    /// <summary>
    /// Retrieves all packages.
    /// </summary>
    /// <returns>
    /// List of packages.
    /// </returns>
    public async Task<List<AurPackageDto>> GetAllPackagesAsync() => [..(await _packRepos.GetAllPackagesAsync()).Select(AurPackageMapper.GetDto)];

    /// <summary>
    /// Adds new package data to storage.
    /// </summary>
    /// <param name="packageDto">Package data.</param>
    public async Task AddAsync(AurPackageDto packageDto)
    {
        ArgumentNullException.ThrowIfNull(packageDto);
        AurPackage? existingPackage = await _packRepos.GetPackageAsync(packageDto.ID);
        if (existingPackage != null) return;
        AurPackage package = AurPackageMapper.GetAurPackage(packageDto);
        _packRepos.Add(package);
    }

    /// <summary>
    /// Adds new packages data to storage.
    /// </summary>
    /// <param name="packageDto">Collection of packages data.</param>
    public async Task AddPackages(IEnumerable<AurPackageDto> packageDto)
    {
        foreach (var package in packageDto) 
            await AddAsync(package);
    }
}