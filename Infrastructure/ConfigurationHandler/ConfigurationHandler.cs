using System.Text.Json;
using Application.Configuration;
using Application.ConfigurationHandler.Interfaces;

namespace Infrastructure.ConfigurationHandler;

/// <summary>
/// Application configuration handler working with the filename file.
/// </summary>
/// <param name="filename">Configuration file name.</param>
public class ConfigurationHandler(string filename) : IConfigurationHandler
{
    private readonly string _path = Path.Combine(AppContext.BaseDirectory, filename);

    /// <summary>
    /// Loads the current configuration file and saves it to AppConfig.
    /// </summary>
    /// <returns>
    /// AppConfig if it was found and deserialized.
    /// </returns>
    /// <exception cref="InvalidOperationException">Thrown when the configuration file could not be deserialized.</exception>
    public AppConfig Load()
    {
        var json = File.ReadAllText(_path);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<AppConfig>(json, options) ?? throw new InvalidOperationException("invalid configuration file");
    }

    /// <summary>
    /// Saves AppConfig to a configuration file.
    /// </summary>
    /// <param name="config">AppCpnfig to saving.</param>
    public void Save(AppConfig config)
    {
        var json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_path, json);
    }
}