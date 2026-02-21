using MongoDB.Driver;
using Domain.Repositories.Interfaces;
using Domain.Models;
using Infrastructure.MongoDb.Models;
using Infrastructure.MongoDb.Mapping;

namespace Infrastructure.MongoDb.Repositories;

public class ArticleRepository(IMongoCollection<WebArticle> webArticles) : IArticleRepository
{
    private readonly IMongoCollection<WebArticle> _webArticles = webArticles;

    public async Task<Article?> GetArticleAsync(string url)
    {
        var filter = Builders<WebArticle>.Filter.Eq(a => a.URL, url);
        var webArticle = await _webArticles.Find(filter).FirstOrDefaultAsync();
        if (webArticle == null) return null;
        Article article = ArticleMapper.GetArticle(webArticle);
        return article;
    }

    public async Task<List<Article>> GetAllArticlesAsync()
    {
        var webArticles = await _webArticles.Find(_ => true).ToListAsync();
        List<Article> allArticles = [.. webArticles.Select(ArticleMapper.GetArticle)];
        return allArticles;
    }

    public async Task AddAsync(Article article)
    {
        WebArticle webArticle = ArticleMapper.GetWebArticle(article);
        await _webArticles.InsertOneAsync(webArticle);
    }
}