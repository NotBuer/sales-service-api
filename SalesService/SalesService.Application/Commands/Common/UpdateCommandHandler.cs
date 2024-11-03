using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;
using SalesService.Application.Services.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Commands.Common;

public class UpdateCommandHandler<TRequest, TResponse, TContent, TEntity>(
    IRequestHandlerService<TRequest, TContent, TEntity> requestHandlerService) : 
    IUpdateCommandHandler<TRequest, TResponse, TContent, TEntity>
    where TRequest : IUpdateRequest
    where TResponse : Response<TContent>, new()
    where TContent : class
    where TEntity : class
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var validationResult = new ValidationResult();

        var requestHandlerContent = await requestHandlerService.UpdateAsync(request, validationResult, cancellationToken);

        validationResult.Add(requestHandlerContent.ValidationResult);

        return new TResponse()
        {
            Content = requestHandlerContent.Content,
            Metadata = new Metadata("Okay", "Update executed successfully!", DateTime.UtcNow),
            ValidationResult = validationResult
        };
    }
}