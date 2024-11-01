using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;

namespace SalesService.Application.Commands.Common;

public class AddCommandHandler<TRequest, TResponse, TEntity> : IAddCommandHandler<TRequest, TResponse, TEntity>
    where TRequest : IAddRequest
    where TResponse : IResponse
{
    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}