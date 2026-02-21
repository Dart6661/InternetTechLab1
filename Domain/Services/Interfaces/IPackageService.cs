using Shared.Dtos;

namespace Domain.Services.Interfaces;

public interface IPackageService
{
    Task<AurPackageDto> GetPackageAsync(int id);
    Task<AurPackageDto> GetPackageAsync(string name);
    Task<List<AurPackageDto>> GetAllPackagesAsync();
    Task AddAsync(AurPackageDto packageDto);
    Task AddPackages(IEnumerable<AurPackageDto> packDtos);
}