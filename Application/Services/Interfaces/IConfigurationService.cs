namespace Application.Services.Interfaces;

public interface IConfigurationService
{
    string GetPgDbConnectionString();
    string GetMongoDbConnectionString();
    string GetMongoDbName();
    string GetAurBaseUrl();
    void SetPgDbConnectionString(string connectionString);
    void SetMongoDbConnectionString(string connectionString);
}
