namespace SalesService.Domain.Interfaces;

public interface IRepository<TEntity> : IWriteRepository<TEntity>, IReadRepository<TEntity>
    where TEntity : class
{
    
}