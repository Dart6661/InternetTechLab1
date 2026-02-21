using System.Text.Json.Serialization;

namespace Infrastructure.AUR.Models;

public class AurResponse
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("results")]
    public List<AurPackageRaw> Packages { get; set; } = [];
}