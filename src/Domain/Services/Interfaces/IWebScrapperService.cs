using Shared.Dtos;

namespace Domain.Services.Interfaces;

/// <summary>
/// Defines domain-level operations for working with web scraper.
/// </summary>
public interface IWebScraperService
{
    /// <summary>
    /// Loads article from the Internet.
    /// </summary>
    /// <param name="url">Article url.</param>
    /// <returns>
    /// Article data.
    /// </returns>
    Task<ArticleDto> LoadArticleAsync(string url);
}