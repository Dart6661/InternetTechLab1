using Application.Services.Interfaces;
using Application.UnitOfWork.Interfaces;
using Domain.Services.Interfaces;
using Shared.Dtos;

namespace Application.Services;

public class AurService(IUnitOfWork uow, IAurClientService aurClientService, IPackageService packageService) : IAurService
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IAurClientService _aurClientService = aurClientService;
    private readonly IPackageService _packageService = packageService;

    public async Task<List<AurPackageDto>> FindPackageAsync(string name)
    {
        AurResponseDto response = await _aurClientService.FindPackageAsync(name);
        await _packageService.AddPackages(response.Packages);
        await _uow.CommitChangesAsync();
        return response.Packages;
    }

    public async Task<AurPackageDto> GetPackageAsync(int id) => await _packageService.GetPackageAsync(id);

    public async Task<AurPackageDto> GetPackageAsync(string name) => await _packageService.GetPackageAsync(name);

    public async Task<List<AurPackageDto>> GetAllPackagesAsync() => await _packageService.GetAllPackagesAsync();
}