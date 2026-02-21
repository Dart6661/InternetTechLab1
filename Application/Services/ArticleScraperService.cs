using Application.Services.Interfaces;
using Domain.Services.Interfaces;
using Shared.Dtos;

namespace Application.Services;

public class ArticleScraperService(IArticleService articleService, IWebScraperService scraperService) : IArticleScraperService
{
    private readonly IWebScraperService _scraperService = scraperService;
    private readonly IArticleService _articleService = articleService;

    public async Task<ArticleDto> LoadArticleAsync(string url)
    {
        ArticleDto articleDto = await _scraperService.LoadArticleAsync(url);
        await _articleService.AddAsync(articleDto);
        return articleDto;
    }

    public async Task<ArticleDto> GetArticleAsync(string url) => await _articleService.GetArticleAsync(url);

    public async Task<List<ArticleDto>> GetAllArticlesAsync() => await _articleService.GetAllArticlesAsync();
}