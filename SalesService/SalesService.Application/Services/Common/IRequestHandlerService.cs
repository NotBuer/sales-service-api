using SalesService.Application.Requests.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Services.Common;

public interface IRequestHandlerService<TRequest, TEntity>
    where TRequest : IRequest
    where TEntity : class
{
    Task<ValidationResult> AddAsync (TRequest request, CancellationToken cancellationToken);
    Task<ValidationResult> UpdateAsync (TRequest request, CancellationToken cancellationToken);
    Task<ValidationResult> DeleteAsync (TRequest request, CancellationToken cancellationToken);
}