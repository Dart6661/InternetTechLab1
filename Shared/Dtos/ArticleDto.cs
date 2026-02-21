namespace Shared.Dtos;

public record ArticleDto
(
    string Id,
    string URL,
    string? Title,
    List<string> Tags,
    List<Dictionary<string, string>> Metatags,
    Dictionary<string, string> Links
);