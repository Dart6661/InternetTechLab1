using Domain.APIs.Interfaces;
using Domain.Services.Interfaces;
using Shared.Dtos;

namespace Domain.Services;

/// <summary>
/// Service for working with web scraper.
/// </summary>
/// <param name="scraper">Web scraper.</param>
public class WebScraperService(IWebScraper scraper) : IWebScraperService
{
    private readonly IWebScraper _scraper = scraper;

    /// <summary>
    /// Loads article from the Internet.
    /// </summary>
    /// <param name="url">Article url</param>
    /// <returns>
    /// Article data.
    /// </returns>
    public Task<ArticleDto> LoadArticleAsync(string url) => _scraper.LoadArticleAsync(url);
}