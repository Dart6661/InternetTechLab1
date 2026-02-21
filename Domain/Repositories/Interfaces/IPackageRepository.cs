using Domain.Models;

namespace Domain.Repositories.Interfaces;

public interface IPackageRepository
{
    Task<AurPackage?> GetPackageAsync(int id);
    Task<AurPackage?> GetPackageAsync(string name);
    Task<List<AurPackage>> GetAllPackagesAsync();
    void Add(AurPackage package);
}