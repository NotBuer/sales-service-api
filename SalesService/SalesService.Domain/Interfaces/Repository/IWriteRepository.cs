namespace SalesService.Domain.Interfaces.Repository;

public interface IWriteRepository<TEntity> 
    where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity?> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
}