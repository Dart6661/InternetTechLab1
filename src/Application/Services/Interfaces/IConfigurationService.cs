namespace Application.Services.Interfaces;

/// <summary>
/// Defines operations for working with configuration.
/// </summary>
public interface IConfigurationService
{
    /// <summary>
    /// Retrieves PostgreSQL connection string. 
    /// </summary>
    /// <returns>
    /// PostgreSQL connection string.
    /// </returns>
    string GetPgDbConnectionString();

    /// <summary>
    /// Retrieves MongoDB connection string.
    /// </summary>
    /// <returns>
    /// MongoDB connection string.
    /// </returns>
    string GetMongoDbConnectionString();

    /// <summary>
    /// Retrieves MongoDB database name.
    /// </summary>
    /// <returns>
    /// MongoDB name.
    /// </returns>
    string GetMongoDbName();

    /// <summary>
    /// Retrieves AUR base url.
    /// </summary>
    /// <returns>
    /// AUR base url.
    /// </returns>
    string GetAurBaseUrl();

    /// <summary>
    /// Sets the connection string to PostgreSQL.
    /// </summary>
    /// <param name="connectionString">new PostgreSQL connection string.</param>
    void SetPgDbConnectionString(string connectionString);

    /// <summary>
    /// Sets the connection string to MongoDB.
    /// </summary>
    /// <param name="connectionString">new MongoDB connection string.</param>
    void SetMongoDbConnectionString(string connectionString);
}
