using Domain.Models;
using Shared.Dtos;

namespace Domain.Mapping;

public static class AurPackageMapper
{
    public static AurPackageDto GetDto(AurPackage package) => new(package.ID, package.Name, package.Version, package.URL, package.Description);

    public static AurPackage GetAurPackage(AurPackageDto dto) => new(dto.ID, dto.Name, dto.Version, dto.URL, dto.Description);
}