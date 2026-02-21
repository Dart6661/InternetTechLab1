using Microsoft.EntityFrameworkCore;
using Infrastructure.PostgreDb.Context;
using Domain.Repositories.Interfaces;
using Domain.Models;

namespace Infrastructure.PostgreDb.Repositories;

public class PackageRepository(AurSearchContext context) : IPackageRepository
{
    private readonly AurSearchContext _context = context;

    public async Task<AurPackage?> GetPackageAsync(int id) => await _context.Packages.FirstOrDefaultAsync(p => p.ID == id);

    public async Task<AurPackage?> GetPackageAsync(string name) => await _context.Packages.FirstOrDefaultAsync(p => p.Name == name);

    public async Task<List<AurPackage>> GetAllPackagesAsync() =>  await _context.Packages.ToListAsync();

    public void Add(AurPackage package) => _context.Packages.Add(package);
}