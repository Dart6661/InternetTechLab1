using Shared.Dtos;

namespace Domain.APIs.Interfaces;

/// <summary>
/// Defines a client for interacting with the AUR API.
/// </summary>
public interface IAurClient
{
    /// <summary>
    /// Searches for a package by its name.
    /// </summary>
    /// <param name="name">Package name.</param>
    /// <returns>
    /// AUR response dto.
    /// </returns>
    Task<AurResponseDto> FindPackageAsync(string name);
}