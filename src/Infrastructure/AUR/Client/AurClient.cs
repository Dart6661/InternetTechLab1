using System.Text.Json;
using Infrastructure.AUR.Mapping;
using Infrastructure.AUR.Models;
using Domain.APIs.Interfaces;

using Shared.Dtos;

namespace Infrastructure.AUR.Client;

/// <summary>
/// Client for working with the AUR API.
/// </summary>
/// <param name="factory">Factory for creating HttpClient with the required configuration.</param>
public class AurClient(IHttpClientFactory factory) : IAurClient
{
    private readonly HttpClient _httpClient = factory.CreateClient("AurClient");

    /// <summary>
    /// Searches for packages containing name in the name or description.
    /// </summary>
    /// <param name="name">Package name</param>
    /// <returns>
    /// AUR response dto.
    /// </returns>
    /// <exception cref="JsonException">Thrown when the AUR response json could not be deserialized.</exception>
    public async Task<AurResponseDto> FindPackageAsync(string name)
    {
        string url = $"search/{Uri.EscapeDataString(name)}";
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string json = await response.Content.ReadAsStringAsync();
        AurResponse aurResponse = JsonSerializer.Deserialize<AurResponse>(json) ?? throw new JsonException("deserialization error");
        AurResponseDto responseDto = AurResponseMapper.GetDto(aurResponse);
        return responseDto;
    }
}