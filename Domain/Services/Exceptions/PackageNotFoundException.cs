namespace Domain.Services.Exceptions;

/// <summary>
/// Exception thrown when an package cannot be found in the repository.
/// </summary>
/// <param name="message">Exception message.</param>
public class PackageNotFoundException(string message) : Exception(message);