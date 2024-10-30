using System.Linq.Expressions;

namespace SalesService.Domain.Interfaces;

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