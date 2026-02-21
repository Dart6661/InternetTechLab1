namespace Domain.Models;

public class Article
{
    public string Id { get; set; } = null!;
    public string URL { get; set; } = null!;
    public string? Title { get; set; } = null!;
    public List<string> Tags { get; set; } = [];
    public List<Dictionary<string, string>> Metatags { get; set; } = [];
    public Dictionary<string, string> Links { get; set; } = [];

}