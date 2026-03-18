using Microsoft.EntityFrameworkCore;
using Infrastructure.PostgreDb.Context;
using Domain.Repositories.Interfaces;
using Domain.Models;

namespace Infrastructure.PostgreDb.Repositories;

/// <summary>
/// Repository for working with the packages table.
/// </summary>
/// <param name="context">Database context.</param>
public class PackageRepository(AurSearchContext context) : IPackageRepository
{
    private readonly AurSearchContext _context = context;

    /// <summary>
    /// Retrieves a package by its identifier.
    /// </summary>
    /// <param name="id">Package identifier.</param>
    /// <returns>
    /// Package if found, otherwise null.
    /// </returns>
    public async Task<AurPackage?> GetPackageAsync(int id) => await _context.Packages.FirstOrDefaultAsync(p => p.ID == id);

    /// <summary>
    /// Retrieves a package by its name.
    /// </summary>
    /// <param name="name">Package name</param>
    /// <returns>
    /// Package if found, otherwise null.
    /// </returns>
    public async Task<AurPackage?> GetPackageAsync(string name) => await _context.Packages.FirstOrDefaultAsync(p => p.Name == name);

    /// <summary>
    /// Retrieves all packages from database.
    /// </summary>
    /// <returns>
    /// List containing all packages.
    /// </returns>
    public async Task<List<AurPackage>> GetAllPackagesAsync() =>  await _context.Packages.ToListAsync();

    /// <summary>
    /// Adds a new package to the context.
    /// </summary>
    /// <param name="package">Package to add</param>
    public void Add(AurPackage package) => _context.Packages.Add(package);
}