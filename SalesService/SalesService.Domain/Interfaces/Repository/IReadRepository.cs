using System.Linq.Expressions;

namespace SalesService.Domain.Interfaces.Repository;

public interface IReadRepository<TEntity> 
    where TEntity : class
{
    Task<TEntity?> GetByIdAsync(
        Guid id, 
        bool @readonly = true,
        CancellationToken cancellationToken = default);
    
    Task<IQueryable<TEntity>> SearchAsync(
        Expression<Func<TEntity, bool>> predicate, 
        bool @readonly = true,
        CancellationToken cancellationToken = default);
}