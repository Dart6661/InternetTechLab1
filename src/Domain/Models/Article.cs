namespace Domain.Models;

/// <summary>
/// Represents an article in the domain model.
/// </summary>
/// <param name="id">Unique article identifier.</param>
/// <param name="url">Source URL of the article.</param>
/// <param name="title">Article title. Null if not found.</param>
/// <param name="tags">List of article tags.</param>
/// <param name="metatags">List of meta tag attributes.</param>
/// <param name="links">Dictionary of extracted links.</param>
public class Article(string id, string url, string? title, List<string> tags, List<Dictionary<string, string>> metatags, Dictionary<string, string> links)
{
    public string Id { get; } = id;
    public string URL { get; } = url;
    public string? Title { get; } = title;
    public List<string> Tags { get; } = tags;
    public List<Dictionary<string, string>> Metatags { get; } = metatags;
    public Dictionary<string, string> Links { get; } = links;

}