using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Infrastructure.MongoDb.Models;

/// <summary>
/// Represents a MongoDB document storing parsed web article data.
/// </summary>
public class WebArticle
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string URL { get; set; } = null!;
    public string? Title { get; set; } 
    public List<string> Tags { get; set; } = [];
    public List<Dictionary<string, string>> Metatags { get; set; } = [];
    public Dictionary<string, string> Links { get; set; } = [];
}