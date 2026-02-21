namespace Application.Configuration;

public class AppConfig
{
    public AurConfig AurConfig { get; set; } = new();
    public PostgresConfig PostgresConfig { get; set; } = new();
    public MongoConfig MongoConfig { get; set; } = new();
}