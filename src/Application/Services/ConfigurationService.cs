using Application.Services.Interfaces;
using Application.ConfigurationHandler.Interfaces;
using Application.Configuration;

namespace Application.Services;

/// <summary>
/// Service for working with configuration.
/// </summary>
public class ConfigurationService(IConfigurationHandler handler) : IConfigurationService
{
    private readonly IConfigurationHandler _handler = handler;
    private readonly AppConfig _config = handler.Load();

    /// <summary>
    /// Retrieves PostgreSQL connection string. 
    /// </summary>
    /// <returns>
    /// PostgreSQL connection string.
    /// </returns>
    public string GetPgDbConnectionString() => _config.PostgresConfig.ConnectionString;

    /// <summary>
    /// Retrieves MongoDB connection string.
    /// </summary>
    /// <returns>
    /// MongoDB connection string.
    /// </returns>
    public string GetMongoDbConnectionString() => _config.MongoConfig.ConnectionString;

    /// <summary>
    /// Retrieves MongoDB database name.
    /// </summary>
    /// <returns>
    /// MongoDB name.
    /// </returns>
    public string GetMongoDbName() => _config.MongoConfig.DbName;
    
    /// <summary>
    /// Retrieves AUR base url.
    /// </summary>
    /// <returns>
    /// AUR base url.
    /// </returns>
    public string GetAurBaseUrl() => _config.AurConfig.BaseUrl;

    /// <summary>
    /// Sets the connection string to PostgreSQL.
    /// </summary>
    /// <param name="connectionString">new PostgreSQL connection string.</param>
    public void SetPgDbConnectionString(string connectionString)
    {
        _config.PostgresConfig.ConnectionString = connectionString;
        _handler.Save(_config);
    }

    /// <summary>
    /// Sets the connection string to MongoDB.
    /// </summary>
    /// <param name="connectionString">new MongoDB connection string.</param>
    public void SetMongoDbConnectionString(string connectionString)
    {
        _config.MongoConfig.ConnectionString = connectionString;
        _handler.Save(_config);
    }
}