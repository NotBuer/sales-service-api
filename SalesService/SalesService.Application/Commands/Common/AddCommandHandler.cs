using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;
using SalesService.Application.Services.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Commands.Common;

public class AddCommandHandler<TRequest, TResponse, TContent, TEntity>(
    IRequestHandlerService<TRequest, TContent, TEntity> requestHandlerService) : 
    IAddCommandHandler<TRequest, TResponse, TContent, TEntity>
    where TRequest : IAddRequest
    where TResponse : Response<TContent>, new()
    where TContent : class
    where TEntity : class
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var validationResult = new ValidationResult();

        var requestHandlerContent = await requestHandlerService.AddAsync(request, validationResult, cancellationToken);

        return new TResponse()
        {
            Content =  requestHandlerContent.Content,
            Metadata = new Metadata("Okay", "Create executed successfully!", DateTime.UtcNow)
        };
    }
}