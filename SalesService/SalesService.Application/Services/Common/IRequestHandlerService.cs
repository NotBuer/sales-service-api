using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Services.Common;

public interface IRequestHandlerService<TRequest, TContent, TEntity>
    where TRequest : IRequest
    where TContent : class
    where TEntity : class
{
    Task<RequestHandlerContent<TContent>> AddAsync (
        TRequest request, 
        ValidationResult validationResult, 
        CancellationToken cancellationToken);
    Task<RequestHandlerContent<TContent>> UpdateAsync (
        TRequest request, 
        ValidationResult validationResult, 
        CancellationToken cancellationToken);
    Task<RequestHandlerContent<TContent>> DeleteAsync (
        TRequest request, 
        ValidationResult validationResult, 
        CancellationToken cancellationToken);
}