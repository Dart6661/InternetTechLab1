using Shared.Dtos;

namespace Application.Services.Interfaces;

public interface IArticleScraperService
{
    Task<ArticleDto> LoadArticleAsync(string url);
    Task<ArticleDto> GetArticleAsync(string url);
    Task<List<ArticleDto>> GetAllArticlesAsync();
}