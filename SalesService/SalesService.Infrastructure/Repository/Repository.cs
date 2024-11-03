using System.Linq.Expressions;
using SalesService.Domain.Interfaces.Repository;

namespace SalesService.Infrastructure.Repository;

public sealed class Repository<TEntity>(Context.Context context) : IRepository<TEntity>, IDisposable
    where TEntity : class
{
    private bool _disposed = false;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task<TEntity> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken) =>
        (await _dbSet.AddAsync(entity, cancellationToken)).Entity;

    public async Task<TEntity?> UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken) =>
        await Task.Run(() => _dbSet.Update(entity).Entity, cancellationToken);

    public async Task DeleteAsync(
        TEntity entity,
        CancellationToken cancellationToken) =>
        await Task.Run(() => _dbSet.Remove(entity), cancellationToken);

    public async Task<TEntity?> GetByIdAsync(
        Guid id, 
        bool @readonly = true,
        CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet.FindAsync(new object?[] { id }, cancellationToken: cancellationToken);

        if (@readonly && entity is not null)
            context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public async Task<IQueryable<TEntity>> SearchAsync(
        Expression<Func<TEntity, bool>> predicate,
        bool @readonly = true,
        CancellationToken cancellationToken = default) =>
        await Task.Run(() => @readonly ? 
            _dbSet.Where(predicate).AsNoTracking() : 
            _dbSet.Where(predicate), cancellationToken);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing) context.Dispose();
        _disposed = true;
    }

    ~Repository() => Dispose(false);
}