using Domain.Models;

namespace Domain.Repositories.Interfaces;

/// <summary>
/// Defines a repository for accessing and managing Article entities.
/// </summary>
public interface IArticleRepository
{
    /// <summary>
    /// Retrieves an article by its url.
    /// </summary>
    /// <param name="url">Article url.</param>
    /// <returns>
    /// Article.
    /// </returns>
    Task<Article?> GetArticleAsync(string url);
    
    /// <summary>
    /// Retrieves all articles.
    /// </summary>
    /// <returns>
    /// List of articles.
    /// </returns>
    Task<List<Article>> GetAllArticlesAsync();

    /// <summary>
    /// Adds a new article to the repository.
    /// </summary>
    /// <param name="article">Article to add.</param>
    Task AddAsync(Article article);
}