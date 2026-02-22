namespace Domain.Services.Exceptions;

/// <summary>
/// Exception thrown when an article cannot be found in the repository.
/// </summary>
/// <param name="message">Exception message.</param>
public class ArticleNotFoundException(string message) : Exception(message);