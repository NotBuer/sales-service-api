using Microsoft.EntityFrameworkCore.Storage;
using SalesService.Domain.Entities.Common;

namespace SalesService.Infrastructure.UnitOfWork;

public class UnitOfWork(Context.Context context) : IUnitOfWork, IDisposable
{
    private bool _disposed;
    private IDbContextTransaction? _transaction = null;
    
    public async Task BeginAsync(CancellationToken cancellationToken)
    {
        if (_transaction is not null)
        {
            throw new InvalidOperationException(
                $"Transaction with Id: {_transaction.TransactionId} has already been started!");
        }
        context.ChangeTracker.Entries<Entity>()
        _transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        _disposed = false;
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        try
        {
            await SaveAsync(cancellationToken);
            await _transaction!.CommitAsync(cancellationToken);
        }
        catch (Exception e)
        {
            await RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        await _transaction!.RollbackAsync(cancellationToken);
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _transaction!.Dispose();
            context.Dispose();
        }
        
        this._disposed = true;
    }
}