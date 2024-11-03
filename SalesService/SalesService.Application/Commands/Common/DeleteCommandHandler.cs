using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;
using SalesService.Application.Services.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Commands.Common;

public class DeleteCommandHandler<TRequest, TResponse, TContent, TEntity>(
    IRequestHandlerService<TRequest, TContent, TEntity> requestHandlerService) : 
    IDeleteCommandHandler<TRequest, TResponse, TContent, TEntity>
    where TRequest : IDeleteRequest
    where TResponse : Response<TContent>, new()
    where TContent : class
    where TEntity : class
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var validationResult = new ValidationResult();
        
        var requestHandlerContent = await requestHandlerService.DeleteAsync(request, validationResult, cancellationToken);
        
        return new TResponse()
        {
            Content = requestHandlerContent.Content,
            Metadata = new Metadata("Okay", "Delete executed successfully!", DateTime.UtcNow),
            ValidationResult = validationResult
        };
    }
}