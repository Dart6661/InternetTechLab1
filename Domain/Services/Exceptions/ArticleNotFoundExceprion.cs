namespace Domain.Services.Exceptions;

public class ArticleNotFoundException(string message) : Exception(message);