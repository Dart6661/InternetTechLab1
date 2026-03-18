using Domain.Services.Interfaces;
using Domain.APIs.Interfaces;
using Shared.Dtos;

namespace Domain.Services;

/// <summary>
/// Service for working with AUR client.
/// </summary>
/// <param name="aurClient">AUR client</param>
public class AurClientService(IAurClient aurClient) : IAurClientService
{
    private readonly IAurClient _aurClient = aurClient;

    /// <summary>
    /// Searches for packages in AUR.
    /// </summary>
    /// <param name="name">Package name.</param>
    /// <returns>
    /// AUR response data.
    /// </returns>
    public async Task<AurResponseDto> FindPackageAsync(string name) => await _aurClient.FindPackageAsync(name);
}