namespace Application.UnitOfWork.Interfaces;

/// <summary>
/// Defines Unit of Work pattern.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Saves changes.
    /// </summary>
    Task CommitChangesAsync();
}