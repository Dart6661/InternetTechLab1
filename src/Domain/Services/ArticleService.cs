using Domain.Mapping;
using Domain.Models;
using Domain.Repositories.Interfaces;
using Domain.Services.Exceptions;
using Domain.Services.Interfaces;
using Shared.Dtos;

namespace Domain.Services;

/// <summary>
/// Service for working with articles.
/// </summary>
/// <param name="articleRepos">Articles repository.</param>
public class ArticleSevice(IArticleRepository articleRepos) : IArticleService
{
    private readonly IArticleRepository _articleRepos = articleRepos;

    /// <summary>
    /// Retrieves an article by its url.
    /// </summary>
    /// <param name="url">Article url.</param>
    /// <returns>
    /// Article data.
    /// </returns>
    /// <exception cref="ArticleNotFoundException">Thrown when article cannot be found.</exception>
    public async Task<ArticleDto> GetArticleAsync(string url)
    {
        ArgumentException.ThrowIfNullOrEmpty(url);
        Article article = await _articleRepos.GetArticleAsync(url) ?? throw new ArticleNotFoundException($"article with url {url} not found");
        ArticleDto articleDto = ArticleMapper.GetDto(article);
        return articleDto;
    }

    /// <summary>
    /// Retrieves all articles.
    /// </summary>
    /// <returns>
    /// List of articles data.
    /// </returns>
    public async Task<List<ArticleDto>> GetAllArticlesAsync()
    {
        List<Article> articles = await _articleRepos.GetAllArticlesAsync();
        List<ArticleDto> articleDtos = [.. articles.Select(ArticleMapper.GetDto)];
        return articleDtos;
    }

    /// <summary>
    /// Adds new article data to storage.
    /// </summary>
    /// <param name="articleDto">Article data.</param>
    public async Task AddAsync(ArticleDto articleDto)
    {
        ArgumentNullException.ThrowIfNull(articleDto);
        Article article = ArticleMapper.GetArticle(articleDto);
        await _articleRepos.AddAsync(article);
    }
}