using SalesService.Application.Requests.Common;
using SalesService.Application.Validations.Common;
using SalesService.Domain.Interfaces.Repository;
using SalesService.Domain.Interfaces.Service;
using SalesService.Domain.Validations;

namespace SalesService.Application.Services;

public class Service<TRequest, TEntity>(
    IWriteRepository<TEntity> writeRepository,
    RequestValidator<TRequest> requestValidator,
    ValidationResult validationResult) : IWriteService<TEntity>
    where TRequest : IRequest
    where TEntity : class 
{
    public Task<ValidationResult> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ValidationResult> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ValidationResult> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}