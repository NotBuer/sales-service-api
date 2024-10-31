namespace SalesService.Domain.Interfaces.Repository;

public interface IRepository<TEntity> : IWriteRepository<TEntity>, IReadRepository<TEntity>
    where TEntity : class
{
    
}