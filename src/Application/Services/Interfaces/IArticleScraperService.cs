using Shared.Dtos;

namespace Application.Services.Interfaces;

/// <summary>
/// Defines application-level operations for working with articles.
/// </summary>
public interface IArticleScraperService
{
    /// <summary>
    /// Loads an article from the Internet and saves it.
    /// </summary>
    /// <param name="url">Article url.</param>
    /// <returns>
    /// Article data.
    /// </returns>
    Task<ArticleDto> LoadArticleAsync(string url);

    /// <summary>
    /// Retrieves an article by its url.
    /// </summary>
    /// <param name="url">Article url.</param>
    /// <returns>
    /// Article data.
    /// </returns>
    Task<ArticleDto> GetArticleAsync(string url);

    /// <summary>
    /// Retrieves all articles.
    /// </summary>
    /// <returns>
    /// List of articles data.
    /// </returns>
    Task<List<ArticleDto>> GetAllArticlesAsync();
}