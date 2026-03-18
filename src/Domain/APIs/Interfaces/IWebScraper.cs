using Shared.Dtos;

namespace Domain.APIs.Interfaces;

/// <summary>
/// Defines a scraper for parsing articles.
/// </summary>
public interface IWebScraper
{
    /// <summary>
    /// Loads the article by its url.
    /// </summary>
    /// <param name="url">Article url.</param>
    /// <returns>
    /// Article dto.
    /// </returns>
    Task<ArticleDto> LoadArticleAsync(string url);
}