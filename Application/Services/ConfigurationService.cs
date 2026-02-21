using Application.Services.Interfaces;
using Application.ConfigurationHandler.Interfaces;
using Application.Configuration;

namespace Application.Services;

public class ConfigurationService : IConfigurationService
{
    private readonly IConfigurationHandler _handler;
    private readonly AppConfig _config;

    public ConfigurationService(IConfigurationHandler handler)
    {
        _handler = handler;
        _config = _handler.Load();
    }

    public string GetPgDbConnectionString() => _config.PostgresConfig.ConnectionString;

    public string GetMongoDbConnectionString() => _config.MongoConfig.ConnectionString;

    public string GetMongoDbName() => _config.MongoConfig.DbName;
    
    public string GetAurBaseUrl() => _config.AurConfig.BaseUrl;

    public void SetPgDbConnectionString(string connectionString)
    {
        _config.PostgresConfig.ConnectionString = connectionString;
        _handler.Save(_config);
    }

    public void SetMongoDbConnectionString(string connectionString)
    {
        _config.MongoConfig.ConnectionString = connectionString;
        _handler.Save(_config);
    }
}