namespace Domain.Models;

public class Article(string id, string url, string? title, List<string> tags, List<Dictionary<string, string>> metatags, Dictionary<string, string> links)
{
    public string Id { get; } = id;
    public string URL { get; } = url;
    public string? Title { get; } = title;
    public List<string> Tags { get; } = tags;
    public List<Dictionary<string, string>> Metatags { get; } = metatags;
    public Dictionary<string, string> Links { get; } = links;

}