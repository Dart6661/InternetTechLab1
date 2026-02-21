using Domain.Services.Interfaces;
using Domain.APIs.Interfaces;
using Shared.Dtos;

namespace Domain.Services;

public class AurClientService(IAurClient aurClient) : IAurClientService
{
    private readonly IAurClient _aurClient = aurClient;

    public async Task<AurResponseDto> FindPackageAsync(string name) => await _aurClient.FindPackageAsync(name);
}