using Shared.Dtos;

namespace Domain.Services.Interfaces;

/// <summary>
/// Defines domain-level operations for working with articles.
/// </summary>
public interface IArticleService
{
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

    /// <summary>
    /// Adds a new article.
    /// </summary>
    /// <param name="articleDto">Article data to add</param>
    Task AddAsync(ArticleDto articleDto);
}