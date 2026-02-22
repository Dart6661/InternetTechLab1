using System.CommandLine;
using Application.Services.Interfaces;
using Domain.Models;
using Shared.Dtos;

namespace Presentation.Dispatcher;

public class CommandDispatcher
{
    private readonly IAurService _aur;
    private readonly IArticleScraperService _scraper;
    private readonly IConfigurationService _config;
    private readonly RootCommand _root;

    private readonly Option<string> _fileNameOption;
    private readonly Option<string> _urlOption;
    private readonly Option<string> _pgDbConnectionOption;
    private readonly Option<string> _mongoDbConnectionOption;
    private readonly Option<bool> _articleDbOption;
    private readonly Option<bool> _packageDbOption;
    private readonly Option<bool> _allOption;
    private readonly Option<bool> _infoOption;
    private readonly Option<bool> _setOption;

    private readonly Command _fingCommand;
    private readonly Command _loadCommand;
    private readonly Command _getCommand;
    private readonly Command _configCommand;

    public CommandDispatcher(IAurService aur, IArticleScraperService scraper, IConfigurationService config)
    {
        _aur = aur;
        _scraper = scraper;
        _config = config;

        _packageDbOption = new("--package") { Description = "select a package repository" };
        _articleDbOption = new("--article") { Description = "select the article repository" };
        _fileNameOption = new("--file-name", "-n") { Description = "name of the requested file" };
        _urlOption = new("--url", "-u") { Description = "full resource url" };
        _allOption = new("--all", "-a") { Description = "get all values" };
        _pgDbConnectionOption = new("--postgres-connection", "-pc") { Description = "postgresql connection string" };
        _mongoDbConnectionOption = new("--mongo-connection", "-mc") { Description = "mongodb connection string" };
        _infoOption = new("--info", "-i") { Description = "get information" };
        _setOption = new("--set", "-s") { Description = "set configuration parameters" };

        _root = new("tool for searching packages in AUR");

        _fingCommand = new("find", "find a package in AUR") { _fileNameOption };
        _fingCommand.SetAction(Safe(FindCommand));

        _loadCommand = new("load", "load article data") { _urlOption };
        _loadCommand.SetAction(Safe(LoadCommand));

        _getCommand = new("get", "get data from the database") { _packageDbOption, _articleDbOption, _fileNameOption, _urlOption, _allOption };
        _getCommand.SetAction(Safe(GetCommand));

        _configCommand = new("config", "configuration parameters") { _infoOption, _setOption, _pgDbConnectionOption, _mongoDbConnectionOption };
        _configCommand.SetAction(Safe(ConfigCommand));

        _root.Subcommands.Add(_fingCommand);
        _root.Subcommands.Add(_loadCommand);
        _root.Subcommands.Add(_getCommand);
        _root.Subcommands.Add(_configCommand);
    }

    public async Task ProcessCommand(string[] args) => await _root.Parse(args).InvokeAsync();

    public async Task FindCommand(ParseResult args, CancellationToken token)
    {
        List<AurPackageDto> packages = await _aur.FindPackageAsync(args.GetValue(_fileNameOption) ?? throw new ArgumentNullException("file name required"));
        Console.WriteLine("\npackages:");
        foreach (var package in packages) Console.WriteLine($"{package.Name} - {package.Description}");
        Console.WriteLine($"number of results: {packages.Count}");
        Console.WriteLine();
    }

    public async Task LoadCommand(ParseResult args, CancellationToken token)
    {
        ArticleDto article = await _scraper.LoadArticleAsync(args.GetValue(_urlOption) ?? throw new ArgumentNullException("url required"));
        Console.WriteLine("\narticle:");
        Console.WriteLine($"url: {article.URL}\ntitle: {article.Title}");
        Console.WriteLine("tags:");
        foreach (var tag in article.Tags) Console.WriteLine(tag);
        Console.WriteLine("metatags:");
        foreach (var metatag in article.Metatags) foreach (var kvp in metatag) Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        Console.WriteLine("links:");
        foreach (var link in article.Links) Console.WriteLine($"{link.Key} - {link.Value}");
        Console.WriteLine();
    }

    public async Task GetCommand(ParseResult args, CancellationToken token)
    {
        var pack = args.GetValue(_packageDbOption);
        var art = args.GetValue(_articleDbOption);
        if (pack)
        {
            if (args.GetValue(_allOption))
            {
                List<AurPackageDto> packages = await _aur.GetAllPackagesAsync();
                Console.WriteLine("\naur packages:");
                foreach (var package in packages) Console.WriteLine($"{package.Name} - {package.Description}");
            }
            else
            {
                AurPackageDto package = await _aur.GetPackageAsync(args.GetValue(_fileNameOption) ?? throw new ArgumentNullException("file name required"));
                Console.WriteLine("\naur package:");
                Console.WriteLine($"id: {package.ID}\nname: {package.Name}\ndescription: {package.Description}\nversion: {package.Version}\nurl: {package.URL}");
            }
        }
        if (art)
        {
            if (args.GetValue(_allOption))
            {
                List<ArticleDto> articles = await _scraper.GetAllArticlesAsync();
                Console.WriteLine("\narticles:");
                foreach (var article in articles) Console.WriteLine($"{article.URL} - {article.Title}");
            }
            else
            {
                ArticleDto article = await _scraper.GetArticleAsync(args.GetValue(_urlOption) ?? throw new ArgumentNullException("url required"));
                Console.WriteLine("\narticle:");
                Console.WriteLine($"url: {article.URL}\ntitle: {article.Title}");
                Console.WriteLine("tags:");
                foreach (var tag in article.Tags) Console.WriteLine(tag);
                Console.WriteLine("metatags:");
                foreach (var metatag in article.Metatags) foreach (var kvp in metatag) Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                Console.WriteLine("links:");
                foreach (var link in article.Links) Console.WriteLine($"{link.Key} - {link.Value}");
            }
        }
        if (!pack && !art)
        {
            Console.WriteLine("repository must be specified");
        }
        Console.WriteLine();
    }

    public async Task ConfigCommand(ParseResult args, CancellationToken token)
    {
        Console.WriteLine("\nconfiguration:");
        if (args.GetValue(_infoOption))
        {
            Console.WriteLine($"api url: {_config.GetAurBaseUrl()}");
            Console.WriteLine($"postgresql connection string: {_config.GetPgDbConnectionString()}");
            Console.WriteLine($"mongodb connection string: {_config.GetMongoDbConnectionString()}; db name: {_config.GetMongoDbName()}");
        }
        if (args.GetValue(_setOption))
        {
            var pgDbConnStr = args.GetValue(_pgDbConnectionOption);
            if (pgDbConnStr != null) 
            {
                _config.SetPgDbConnectionString(pgDbConnStr);
                Console.WriteLine("postgresql connection string set");
            }
            var mongoDbConnStr = args.GetValue(_mongoDbConnectionOption);
            if (mongoDbConnStr != null) 
            {
                _config.SetMongoDbConnectionString(mongoDbConnStr);
                Console.WriteLine("mongodb connection string set");
            }
        }
        Console.WriteLine();
    }

    private static Func<ParseResult, CancellationToken, Task> Safe(Func<ParseResult, CancellationToken, Task> action)
    {
        return async (args, token) =>
        {
            try
            {
                await action(args, token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        };
    }

}