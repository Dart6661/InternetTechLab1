using Domain.APIs.Interfaces;
using Domain.Services.Interfaces;
using Shared.Dtos;

namespace Domain.Services;

public class WebScraperService(IWebScraper scraper) : IWebScraperService
{
    private readonly IWebScraper _scraper = scraper;

    public Task<ArticleDto> LoadArticleAsync(string url) => _scraper.LoadArticleAsync(url);
}