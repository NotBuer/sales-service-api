using SalesService.Application.Requests.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Services.Common;

public interface IRequestHandlerService<TRequest, TEntity>
    where TRequest : IRequest
    where TEntity : class
{
    Task<ValidationResult> AddAsync (
        TRequest request, 
        ValidationResult validationResult, 
        CancellationToken cancellationToken);
    Task<ValidationResult> UpdateAsync (
        TRequest request, 
        ValidationResult validationResult, 
        CancellationToken cancellationToken);
    Task<ValidationResult> DeleteAsync (
        TRequest request, 
        ValidationResult validationResult, 
        CancellationToken cancellationToken);
}