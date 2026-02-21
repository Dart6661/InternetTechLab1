using MongoDB.Bson;
using Shared.Dtos;
using Domain.Models;
using Infrastructure.MongoDb.Models;

namespace Infrastructure.MongoDb.Mapping;

public static class ArticleMapper
{
    public static WebArticle GetWebArticle(ArticleDto dto) => new()
    {
        Id = string.IsNullOrEmpty(dto.Id) ? ObjectId.GenerateNewId() : new ObjectId(dto.Id),
        URL = dto.URL,
        Title = dto.Title,
        Tags = dto.Tags,
        Metatags = dto.Metatags,
        Links = dto.Links
    };

    public static WebArticle GetWebArticle(Article article) => new()
    {
        Id = string.IsNullOrEmpty(article.Id) ? ObjectId.GenerateNewId() : new ObjectId(article.Id),
        URL = article.URL,
        Title = article.Title,
        Tags = article.Tags,
        Metatags = article.Metatags,
        Links = article.Links
    };

    public static ArticleDto GetDto(WebArticle webArticle) => new
    (
        webArticle.Id.ToString(),
        webArticle.URL,
        webArticle.Title,
        webArticle.Tags,
        webArticle.Metatags,
        webArticle.Links
    );

    public static Article GetArticle(WebArticle webArticle) => new()
    {
        Id = webArticle.Id.ToString(),
        URL = webArticle.URL,
        Title = webArticle.Title,
        Tags = webArticle.Tags,
        Metatags = webArticle.Metatags,
        Links = webArticle.Links
    };
}