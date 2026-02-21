using Application.Configuration;

namespace Application.ConfigurationHandler.Interfaces;

public interface IConfigurationHandler
{
    AppConfig Load();
    void Save(AppConfig config);
}