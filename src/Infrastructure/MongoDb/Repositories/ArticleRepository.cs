using MongoDB.Driver;
using Domain.Repositories.Interfaces;
using Domain.Models;
using Infrastructure.MongoDb.Models;
using Infrastructure.MongoDb.Mapping;

namespace Infrastructure.MongoDb.Repositories;

/// <summary>
/// Repository for working with the articles collection.
/// </summary>
/// <param name="webArticles">Typed collection in MongoDB.</param>
public class ArticleRepository(IMongoCollection<WebArticle> webArticles) : IArticleRepository
{
    private readonly IMongoCollection<WebArticle> _webArticles = webArticles;

    /// <summary>
    /// Retrieves a article by its url.
    /// </summary>
    /// <param name="url">Article url</param>
    /// <returns>
    /// Article if found, otherwise null.
    /// </returns>
    public async Task<Article?> GetArticleAsync(string url)
    {
        var filter = Builders<WebArticle>.Filter.Eq(a => a.URL, url);
        var webArticle = await _webArticles.Find(filter).FirstOrDefaultAsync();
        if (webArticle == null) return null;
        Article article = ArticleMapper.GetArticle(webArticle);
        return article;
    }

    /// <summary>
    /// Retrieves all articles from storage.
    /// </summary>
    /// <returns>
    /// List containing all articles.
    /// </returns>
    public async Task<List<Article>> GetAllArticlesAsync()
    {
        var webArticles = await _webArticles.Find(_ => true).ToListAsync();
        List<Article> allArticles = [.. webArticles.Select(ArticleMapper.GetArticle)];
        return allArticles;
    }

    /// <summary>
    /// Inserts a new article into the storage.
    /// </summary>
    /// <param name="article">Article to add</param>
    public async Task AddAsync(Article article)
    {
        WebArticle webArticle = ArticleMapper.GetWebArticle(article);
        await _webArticles.InsertOneAsync(webArticle);
    }
}