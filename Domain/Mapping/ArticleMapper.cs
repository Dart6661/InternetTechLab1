using Domain.Models;
using Shared.Dtos;

namespace Domain.Mapping;

public static class ArticleMapper
{
    public static ArticleDto GetDto(Article article) => new
    (
        article.Id,
        article.URL,
        article.Title,
        article.Tags,
        article.Metatags,
        article.Links
    );

    public static Article GetArticle(ArticleDto dto) => new()
    {
        Id = dto.Id,
        URL = dto.URL,
        Title = dto.Title,
        Tags = dto.Tags,
        Metatags = dto.Metatags,
        Links = dto.Links
    };
}