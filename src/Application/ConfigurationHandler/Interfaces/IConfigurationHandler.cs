using Application.Configuration;

namespace Application.ConfigurationHandler.Interfaces;

/// <summary>
/// Defines operation to work with configuration file.
/// </summary>
public interface IConfigurationHandler
{
    /// <summary>
    /// Loads the current configuration file and saves it to AppConfig.
    /// </summary>
    /// <returns>
    /// App configuration.
    /// </returns>
    AppConfig Load();

    /// <summary>
    /// Saves AppConfig to a configuration file.
    /// </summary>
    /// <param name="config">AppCpnfig to saving.</param>
    void Save(AppConfig config);
}