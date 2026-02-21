using System.Text.Json;
using Infrastructure.AUR.Mapping;
using Infrastructure.AUR.Models;
using Domain.APIs.Interfaces;

using Shared.Dtos;

namespace Infrastructure.AUR.Client;

public class AurClient(IHttpClientFactory factory) : IAurClient
{
    private readonly HttpClient _httpClient = factory.CreateClient("AurClient");

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