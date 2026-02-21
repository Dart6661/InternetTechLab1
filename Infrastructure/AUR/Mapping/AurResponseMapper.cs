using Infrastructure.AUR.Models;
using Shared.Dtos;

namespace Infrastructure.AUR.Mapping;

public static class AurResponseMapper
{
    public static AurResponseDto GetDto(AurResponse response) => new
    (
        [.. response.Packages
            .Select(AurPackageRawMapper.GetDto)
            .OfType<AurPackageDto>()]
    );
}