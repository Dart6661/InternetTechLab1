using Application.Services.Interfaces;
using Application.UnitOfWork.Interfaces;
using Domain.Services.Interfaces;
using Shared.Dtos;

namespace Application.Services;

/// <summary>
/// Service for working with AUR packages.
/// </summary>
/// <param name="uow">Unit of work service.</param>
/// <param name="aurClientService">Domain-level AUR client service.</param>
/// <param name="packageService">Domain-level package service.</param>
public class AurService(IUnitOfWork uow, IAurClientService aurClientService, IPackageService packageService) : IAurService
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IAurClientService _aurClientService = aurClientService;
    private readonly IPackageService _packageService = packageService;

    /// <summary>
    /// Searches for packages in AUR and save it.
    /// </summary>
    /// <param name="name">Package name.</param>
    /// <returns>
    /// AUR package data.
    /// </returns>
    public async Task<List<AurPackageDto>> FindPackageAsync(string name)
    {
        AurResponseDto response = await _aurClientService.FindPackageAsync(name);
        await _packageService.AddPackages(response.Packages);
        await _uow.CommitChangesAsync();
        return response.Packages;
    }

    /// <summary>
    /// Retrieves an package by its id.
    /// </summary>
    /// <param name="id">Package id</param>
    /// <returns>
    /// AUR package data.
    /// </returns>
    public async Task<AurPackageDto> GetPackageAsync(int id) => await _packageService.GetPackageAsync(id);

    /// <summary>
    /// Retrieves an package by its name.
    /// </summary>
    /// <param name="name">Package name.</param>
    /// <returns>
    /// AUR package data.
    /// </returns>
    public async Task<AurPackageDto> GetPackageAsync(string name) => await _packageService.GetPackageAsync(name);

    /// <summary>
    /// Retrieves all packages.
    /// </summary>
    /// <returns>
    /// List of packages.
    /// </returns>
    public async Task<List<AurPackageDto>> GetAllPackagesAsync() => await _packageService.GetAllPackagesAsync();
}