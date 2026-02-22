namespace Shared.Dtos;

/// <summary>
/// Represents a dto containing parsed article information.
/// </summary>
/// <param name="Id">Unique article identifier.</param>
/// <param name="URL">Source URL of the article.</param>
/// <param name="Title">Article title. Null if not found.</param>
/// <param name="Tags">List of article tags.</param>
/// <param name="Metatags">List of meta tag attributes.</param>
/// <param name="Links">Dictionary of extracted links.</param>
public record ArticleDto
(
    string Id,
    string URL,
    string? Title,
    List<string> Tags,
    List<Dictionary<string, string>> Metatags,
    Dictionary<string, string> Links
);