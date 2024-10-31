namespace SalesService.Domain.Interfaces.Repository;

public interface IWriteRepository<TEntity> 
    where TEntity : class
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
}