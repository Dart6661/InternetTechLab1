using Shared.Dtos;

namespace Domain.Services.Interfaces;

public interface IWebScraperService
{
    Task<ArticleDto> LoadArticleAsync(string url);
}