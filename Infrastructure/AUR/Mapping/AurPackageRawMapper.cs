using Infrastructure.AUR.Models;
using Shared.Dtos;

namespace Infrastructure.AUR.Mapping;

public static class AurPackageRawMapper
{
    public static AurPackageDto? GetDto(AurPackageRaw package) => 
        IsValid(package) 
        ? new AurPackageDto(package.ID, package.Name, package.Version, package.URL, package.Description) 
        : null;

    public static AurPackageRaw GetAurPackage(AurPackageDto dto) => new() 
    { 
        ID = dto.ID, 
        Name = dto.Name, 
        Version = dto.Version, 
        URL = dto.URL, 
        Description = dto.Description 
    };

    public static bool IsValid(AurPackageRaw package) => !string.IsNullOrWhiteSpace(package.Name);
}