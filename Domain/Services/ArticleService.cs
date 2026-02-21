using Domain.Mapping;
using Domain.Models;
using Domain.Repositories.Interfaces;
using Domain.Services.Exceptions;
using Domain.Services.Interfaces;
using Shared.Dtos;

namespace Domain.Services;

public class ArticleSevice(IArticleRepository articleRepos) : IArticleService
{
    private readonly IArticleRepository _articleRepos = articleRepos;

    public async Task<ArticleDto> GetArticleAsync(string url)
    {
        ArgumentException.ThrowIfNullOrEmpty(url);
        Article article = await _articleRepos.GetArticleAsync(url) ?? throw new ArticleNotFoundException($"article with url {url} not found");
        ArticleDto articleDto = ArticleMapper.GetDto(article);
        return articleDto;
    }

    public async Task<List<ArticleDto>> GetAllArticlesAsync()
    {
        List<Article> articles = await _articleRepos.GetAllArticlesAsync();
        List<ArticleDto> articleDtos = [.. articles.Select(ArticleMapper.GetDto)];
        return articleDtos;
    }

    public async Task AddAsync(ArticleDto articleDto)
    {
        ArgumentNullException.ThrowIfNull(articleDto);
        Article article = ArticleMapper.GetArticle(articleDto);
        await _articleRepos.AddAsync(article);
    }
}