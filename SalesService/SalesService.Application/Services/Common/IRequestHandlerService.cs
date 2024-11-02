using SalesService.Application.Requests.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Services.Common;

public interface IRequestHandlerService<TRequest, TEntity>
    where TRequest : IRequest
    where TEntity : class
{
    Task<RequestHandlerContent> AddAsync (
        TRequest request, 
        ValidationResult validationResult, 
        CancellationToken cancellationToken);
    Task<RequestHandlerContent> UpdateAsync (
        TRequest request, 
        ValidationResult validationResult, 
        CancellationToken cancellationToken);
    Task<RequestHandlerContent> DeleteAsync (
        TRequest request, 
        ValidationResult validationResult, 
        CancellationToken cancellationToken);
}