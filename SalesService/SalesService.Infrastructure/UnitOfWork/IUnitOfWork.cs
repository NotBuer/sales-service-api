namespace SalesService.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    Task BeginAsync(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task RollbackAsync(CancellationToken cancellationToken);
    Task SaveAsync(CancellationToken cancellationToken);
}