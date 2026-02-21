using Shared.Dtos;

namespace Domain.Services.Interfaces;

public interface IAurClientService
{
    Task<AurResponseDto> FindPackageAsync(string name);
}