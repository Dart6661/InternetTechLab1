using Shared.Dtos;

namespace Domain.Services.Interfaces;

/// <summary>
/// Defines domain-level operations for working with AUR client.
/// </summary>
public interface IAurClientService
{
    /// <summary>
    /// Searches for packages in AUR.
    /// </summary>
    /// <param name="name">Package name</param>
    /// <returns>
    /// AUR response data.
    /// </returns>
    Task<AurResponseDto> FindPackageAsync(string name);
}