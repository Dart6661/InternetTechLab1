namespace Domain.Services.Exceptions;

public class PackageNotFoundException(string message) : Exception(message);