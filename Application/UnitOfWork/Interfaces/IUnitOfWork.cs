namespace Application.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}