using Shared.Dtos;

namespace Domain.Services.Interfaces;

public interface IArticleService
{
    Task<ArticleDto> GetArticleAsync(string url);
    Task<List<ArticleDto>> GetAllArticlesAsync();
    Task AddAsync(ArticleDto articleDto);
}