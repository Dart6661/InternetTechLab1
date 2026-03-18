using Application.UnitOfWork.Interfaces;
using Infrastructure.PostgreDb.Context;

namespace Infrastructure.PostgreDb.UnitOfWork;

/// <summary>
/// Implementation of the Unit of Work pattern for database context.
/// </summary>
/// <param name="context">Database context for module A.</param>
public class AurSearchUoW(AurSearchContext context) : IUnitOfWork
{
    private readonly AurSearchContext _db = context;

    /// <summary>
    /// Saves changes in context to the database.
    /// </summary>
    public async Task CommitChangesAsync() => await _db.SaveChangesAsync();
}