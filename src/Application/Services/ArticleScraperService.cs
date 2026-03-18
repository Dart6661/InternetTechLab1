using Application.Services.Interfaces;
using Domain.Services.Interfaces;
using Shared.Dtos;

namespace Application.Services;

/// <summary>
/// Service for working with articles.
/// </summary>
/// <param name="articleService">Domain-level article service.</param>
/// <param name="scraperService">Domain-level scraper service.</param>
public class ArticleScraperService(IArticleService articleService, IWebScraperService scraperService) : IArticleScraperService
{
    private readonly IWebScraperService _scraperService = scraperService;
    private readonly IArticleService _articleService = articleService;

    /// <summary>
    /// Loads an article from the Internet and saves it.
    /// </summary>
    /// <param name="url">Article url.</param>
    /// <returns>
    /// Article data.
    /// </returns>
    public async Task<ArticleDto> LoadArticleAsync(string url)
    {
        ArticleDto articleDto = await _scraperService.LoadArticleAsync(url);
        await _articleService.AddAsync(articleDto);
        return articleDto;
    }

    /// <summary>
    /// Retrieves an article by its url.
    /// </summary>
    /// <param name="url">Article url.</param>
    /// <returns>
    /// Article data.
    /// </returns>
    public async Task<ArticleDto> GetArticleAsync(string url) => await _articleService.GetArticleAsync(url);

    /// <summary>
    /// Retrieves all articles.
    /// </summary>
    /// <returns>
    /// List of articles data.
    /// </returns>
    public async Task<List<ArticleDto>> GetAllArticlesAsync() => await _articleService.GetAllArticlesAsync();
}