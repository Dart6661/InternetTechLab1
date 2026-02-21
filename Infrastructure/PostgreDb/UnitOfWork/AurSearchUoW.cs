using Application.UnitOfWork.Interfaces;
using Infrastructure.PostgreDb.Context;

namespace Infrastructure.PostgreDb.UnitOfWork;

public class AurSearchUoW(AurSearchContext context) : IUnitOfWork
{
    private readonly AurSearchContext _db = context;

    public async Task CommitChangesAsync() => await _db.SaveChangesAsync();
}