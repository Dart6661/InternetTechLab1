using Shared.Dtos;

namespace Application.Services.Interfaces;

public interface IAurService
{
    Task<List<AurPackageDto>> FindPackageAsync(string name);
    Task<AurPackageDto> GetPackageAsync(int id);
    Task<AurPackageDto> GetPackageAsync(string name);
    Task<List<AurPackageDto>> GetAllPackagesAsync();
}