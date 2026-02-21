using System.Text.Json;
using Application.Configuration;
using Application.ConfigurationHandler.Interfaces;

namespace Infrastructure.ConfigurationHandler;

public class ConfigurationHandler(string filename) : IConfigurationHandler
{
    private readonly string _path = Path.Combine(AppContext.BaseDirectory, filename);

    public AppConfig Load()
    {
        var json = File.ReadAllText(_path);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<AppConfig>(json, options) ?? throw new InvalidOperationException("invalid configuration file");
    }

    public void Save(AppConfig config)
    {
        var json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_path, json);
    }
}