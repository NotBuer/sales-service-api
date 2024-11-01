using SalesService.Domain.Validations;

namespace SalesService.Domain.Interfaces.Service;

public interface IWriteService<TEntity>
{
    Task<ValidationResult> AddAsync (TEntity entity, CancellationToken cancellationToken);
    Task<ValidationResult> UpdateAsync (TEntity entity, CancellationToken cancellationToken);
    Task<ValidationResult> DeleteAsync (TEntity entity, CancellationToken cancellationToken);
}