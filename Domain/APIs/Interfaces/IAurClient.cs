using Shared.Dtos;

namespace Domain.APIs.Interfaces;

public interface IAurClient
{
    Task<AurResponseDto> FindPackageAsync(string name);
}