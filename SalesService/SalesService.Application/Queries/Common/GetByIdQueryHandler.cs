using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;
using SalesService.Application.Services.Common;

namespace SalesService.Application.Queries.Common;

public class GetByIdQueryHandler<TRequest, TResponse, TContent, TEntity>(
    IRequestHandlerService<TRequest, TContent, TEntity> requestHandlerService)
    : IGetByIdQueryHandler<TRequest, TResponse, TContent, TEntity>
    where TRequest : IGetByIdRequest
    where TResponse : Response<TContent>, new()
    where TContent : class
    where TEntity : class
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var requestHandlerContent = await requestHandlerService.GetByIdAsync(request.Id, true, cancellationToken);

        return new TResponse()
        {
            Content = requestHandlerContent.Content,
            Metadata = new Metadata("Okay", "GetById executed successfully!", DateTime.UtcNow),
            ValidationResult = requestHandlerContent.ValidationResult
        };
    }
}