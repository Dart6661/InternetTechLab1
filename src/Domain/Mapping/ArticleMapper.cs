using Domain.Models;
using Shared.Dtos;

namespace Domain.Mapping;

/// <summary>
/// Provides mapping methods to convert between Article domain objects and article dtos.
/// </summary>
public static class ArticleMapper
{
    /// <summary>
    /// Converts Article to a ArticleDto.
    /// </summary>
    /// <param name="article">Article to convert.</param>
    /// <returns>
    /// Article dto.
    /// </returns>
    public static ArticleDto GetDto(Article article) => new
    (
        article.Id,
        article.URL,
        article.Title,
        article.Tags,
        article.Metatags,
        article.Links
    );

    /// <summary>
    /// Converts ArticleDto to a Article.
    /// </summary>
    /// <param name="dto">ArticleDto to convert.</param>
    /// <returns>
    /// Article
    /// </returns>
    public static Article GetArticle(ArticleDto dto) => new
    (
        dto.Id,
        dto.URL,
        dto.Title,
        dto.Tags,
        dto.Metatags,
        dto.Links
    );
}