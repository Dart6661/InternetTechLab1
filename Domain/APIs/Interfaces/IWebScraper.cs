using Shared.Dtos;

namespace Domain.APIs.Interfaces;

public interface IWebScraper
{
    Task<ArticleDto> LoadArticleAsync(string url);
}