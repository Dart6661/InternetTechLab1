using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Presentation.Dispatcher;
using Application.ConfigurationHandler.Interfaces;
using Application.UnitOfWork.Interfaces;
using Application.Services.Interfaces;
using Application.Services;
using Domain.Repositories.Interfaces;
using Domain.APIs.Interfaces;
using Domain.Services.Interfaces;
using Domain.Services;
using Infrastructure.PostgreDb.Repositories;
using Infrastructure.PostgreDb.UnitOfWork;
using Infrastructure.PostgreDb.Context;
using Infrastructure.AUR.Client;
using Infrastructure.MongoDb.Repositories;
using Infrastructure.MongoDb.Models;
using Infrastructure.WebScraping;
using Infrastructure.ConfigurationHandler;


namespace Presentation.DI;

/// <summary>
/// DI container configuration.
/// </summary>
public static class DIConfig
{
    /// <summary>
    /// Configures the DI container.
    /// </summary>
    /// <returns>
    /// Configured service provider.
    /// </returns>
    public static ServiceProvider ConfigureServices()
    {
        ServiceCollection services = new();
        
        services.AddSingleton<IConfigurationHandler, ConfigurationHandler>(handler =>
        {
            return new ConfigurationHandler("appsettings.json");
        });
        services.AddSingleton<IConfigurationService, ConfigurationService>();

        services.AddSingleton<IMongoClient>(sp => 
        {
            var settings = sp.GetRequiredService<IConfigurationService>();
            return new MongoClient(settings.GetMongoDbConnectionString());
        });
        services.AddSingleton(sp =>
        {
            var settings = sp.GetRequiredService<IConfigurationService>();
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(settings.GetMongoDbName());
        });
        services.AddSingleton(sp =>
        {
            var db = sp.GetRequiredService<IMongoDatabase>();
            return db.GetCollection<WebArticle>("articles");
        });

        services.AddDbContext<AurSearchContext>((sp, options) =>
        {
            var config = sp.GetRequiredService<IConfigurationService>();
            string connectionString = config.GetPgDbConnectionString();
            options.UseNpgsql(connectionString);
        }, ServiceLifetime.Scoped);

        services.AddHttpClient("AurClient", (sp, client) =>
        {
            var config = sp.GetRequiredService<IConfigurationService>();
            client.BaseAddress = new Uri(config.GetAurBaseUrl());
            client.Timeout = TimeSpan.FromSeconds(5);
        });
        services.AddHttpClient("ScraperClient", client =>
        {
            client.Timeout = TimeSpan.FromSeconds(5);
        });

        services.AddScoped<IPackageRepository, PackageRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();

        services.AddScoped<IAurClient, AurClient>();
        services.AddScoped<IWebScraper, WebScraper>();

        services.AddScoped<IPackageService, PackageService>();
        services.AddScoped<IAurClientService, AurClientService>();
        services.AddScoped<IArticleService, ArticleSevice>();
        services.AddScoped<IWebScraperService, WebScraperService>();

        services.AddScoped<IUnitOfWork, AurSearchUoW>();
        services.AddScoped<IAurService, AurService>();
        services.AddScoped<IArticleScraperService, ArticleScraperService>();

        services.AddScoped<CommandDispatcher>();

        return services.BuildServiceProvider();
    }
}