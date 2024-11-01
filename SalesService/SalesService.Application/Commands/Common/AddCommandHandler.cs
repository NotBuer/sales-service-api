using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;
using SalesService.Application.Services.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Commands.Common;

public class AddCommandHandler<TRequest, TResponse, TEntity>(
    IRequestHandlerService<TRequest, TEntity> requestHandlerService) : 
    IAddCommandHandler<TRequest, TResponse, TEntity>
    where TRequest : IAddRequest
    where TResponse : IResponse, new()
    where TEntity : class
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var validationResult = new ValidationResult();
        
        validationResult.Add(await requestHandlerService.AddAsync(request, cancellationToken));

        var response = new TResponse()
        {
            Metadata = new Metadata("Okay", "Metadata AddCommandHandler", DateTime.UtcNow),
            ValidationResult = validationResult
        };

        return response;
    }
}