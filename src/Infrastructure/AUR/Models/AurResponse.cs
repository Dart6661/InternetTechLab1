using System.Text.Json.Serialization;

namespace Infrastructure.AUR.Models;

/// <summary>
/// Represents a raw AUR API response to convert to domain entity.
/// </summary>
public class AurResponse
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("results")]
    public List<AurPackageRaw> Packages { get; set; } = [];
}