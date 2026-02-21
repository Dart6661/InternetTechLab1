using Domain.Models;

namespace Domain.Repositories.Interfaces;

public interface IArticleRepository
{
    Task<Article?> GetArticleAsync(string url);
    Task<List<Article>> GetAllArticlesAsync();
    Task AddAsync(Article article);
}