using Domain.Services.Interfaces;
using Domain.Services.Exceptions;
using Domain.Repositories.Interfaces;
using Domain.Mapping;
using Domain.Models;
using Shared.Dtos;

namespace Domain.Services;

public class PackageService(IPackageRepository packRepos) : IPackageService
{
    private readonly IPackageRepository _packRepos = packRepos;

    public async Task<AurPackageDto> GetPackageAsync(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        AurPackage package = await _packRepos.GetPackageAsync(id) ?? throw new PackageNotFoundException($"package with id {id} not found");
        return AurPackageMapper.GetDto(package);
    }

    public async Task<AurPackageDto> GetPackageAsync(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        AurPackage package = await _packRepos.GetPackageAsync(name) ?? throw new PackageNotFoundException($"package with name {name} not found");
        return AurPackageMapper.GetDto(package);
    }

    public async Task<List<AurPackageDto>> GetAllPackagesAsync() => [..(await _packRepos.GetAllPackagesAsync()).Select(AurPackageMapper.GetDto)];

    public async Task AddAsync(AurPackageDto packageDto)
    {
        ArgumentNullException.ThrowIfNull(packageDto);
        AurPackage? existingPackage = await _packRepos.GetPackageAsync(packageDto.ID);
        if (existingPackage != null) return;
        AurPackage package = AurPackageMapper.GetAurPackage(packageDto);
        _packRepos.Add(package);
    }

    public async Task AddPackages(IEnumerable<AurPackageDto> packageDto)
    {
        foreach (var package in packageDto) 
            await AddAsync(package);
    }
}