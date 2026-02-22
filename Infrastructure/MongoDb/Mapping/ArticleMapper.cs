using MongoDB.Bson;
using Shared.Dtos;
using Domain.Models;
using Infrastructure.MongoDb.Models;

namespace Infrastructure.MongoDb.Mapping;

/// <summary>
/// Provides mapping methods to convert between Article domain objects, dtos and MongoDB documents.
/// </summary>
public static class ArticleMapper
{
    /// <summary>
    /// Converts ArticleDto to a WebArticle document for MongoDB collection.
    /// </summary>
    /// <param name="dto">ArticleDto to convert.</param>
    /// <returns>
    /// Web article.
    /// </returns>
    public static WebArticle GetWebArticle(ArticleDto dto) => new()
    {
        Id = string.IsNullOrEmpty(dto.Id) ? ObjectId.GenerateNewId() : new ObjectId(dto.Id),
        URL = dto.URL,
        Title = dto.Title,
        Tags = dto.Tags,
        Metatags = dto.Metatags,
        Links = dto.Links
    };

    /// <summary>
    /// Converts Article to a WebArticle document for MongoDB collection.
    /// </summary>
    /// <param name="article">Article to convert.</param>
    /// <returns>
    /// Web article.
    /// </returns>
    public static WebArticle GetWebArticle(Article article) => new()
    {
        Id = string.IsNullOrEmpty(article.Id) ? ObjectId.GenerateNewId() : new ObjectId(article.Id),
        URL = article.URL,
        Title = article.Title,
        Tags = article.Tags,
        Metatags = article.Metatags,
        Links = article.Links
    };

    /// <summary>
    /// Converts WebArticle to a Article dto.
    /// </summary>
    /// <param name="webArticle">WebArticle to convert.</param>
    /// <returns>
    /// Article dto.
    /// </returns>
    public static ArticleDto GetDto(WebArticle webArticle) => new
    (
        webArticle.Id.ToString(),
        webArticle.URL,
        webArticle.Title,
        webArticle.Tags,
        webArticle.Metatags,
        webArticle.Links
    );

    /// <summary>
    /// Converts WebArticle to a Article.
    /// </summary>
    /// <param name="webArticle">WebArticle to convert.</param>
    /// <returns>
    /// Article.
    /// </returns>
    public static Article GetArticle(WebArticle webArticle) => new
    (
        webArticle.Id.ToString(),
        webArticle.URL,
        webArticle.Title,
        webArticle.Tags,
        webArticle.Metatags,
        webArticle.Links
    );
}