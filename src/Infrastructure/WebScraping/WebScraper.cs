using HtmlAgilityPack;
using Domain.APIs.Interfaces;
using Shared.Dtos;
using Infrastructure.MongoDb.Models;
using Infrastructure.MongoDb.Mapping;

namespace Infrastructure.WebScraping;

/// <summary>
/// Web article parser.
/// </summary>
/// <param name="factory">Factory for creating HttpClient with the required configuration.</param>
public class WebScraper(IHttpClientFactory factory) : IWebScraper
{
    private readonly HttpClient _httpClient = factory.CreateClient("ScraperClient");

    /// <summary>
    /// Downloads and parses web article by URL.
    /// </summary>
    /// <param name="url">Source URL of the article.</param>
    /// <returns>
    /// Dto containing parsed article information.
    /// </returns>
    public async Task<ArticleDto> LoadArticleAsync(string url)
    {
        string htmlRaw = await _httpClient.GetStringAsync(url);
        HtmlDocument doc = new();
        doc.LoadHtml(htmlRaw);
        WebArticle article = new();
        article.URL = url;
        article.Title = doc.DocumentNode.SelectSingleNode("//title")?.InnerText.Trim();
        article.Tags = [.. doc.DocumentNode.SelectNodes("//h1")?.Select(n => n.InnerText.Trim()) ?? []];
        var metatags = doc.DocumentNode.SelectNodes("//meta");
        if (metatags != null)
        {
            foreach (var node in metatags)
            {
                Dictionary<string, string> attributes = [];
                foreach (var attr in node.Attributes) attributes[attr.Name] = attr.Value;
                article.Metatags.Add(attributes);
            }
        }
        var links = doc.DocumentNode.SelectNodes("//a[@href]");
        if (links != null)
        {
            foreach (var node in links)
            {
                var text = node.InnerText.Trim();
                var link = node.GetAttributeValue("href", "").Trim();
                if (Uri.TryCreate(new Uri(url), link, out var fullUri)) article.Links[fullUri.ToString()] = text;
            }
        }
        ArticleDto articleDto = ArticleMapper.GetDto(article);
        return articleDto;
    }
}