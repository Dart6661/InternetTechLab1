namespace Application.Configuration;

/// <summary>
/// Represents the MongoDb configuration.
/// </summary>
public class MongoConfig
{
    public string ConnectionString { get; set; } = null!;
    public string DbName { get; set; } = null!;
}