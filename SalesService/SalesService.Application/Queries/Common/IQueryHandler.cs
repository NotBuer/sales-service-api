using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;

namespace SalesService.Application.Queries.Common;

public interface IQueryHandler<TRequest, TResponse>
    where TRequest: IRequest
    where TResponse: IResponse
{
    public Task<TResponse> Handle(TRequest request, CancellationToken token);
}

public interface IGetByIdQueryHandler<TRequest, TResponse> : IQueryHandler<TRequest, TResponse> where TRequest : class, IGetByIdRequest where TResponse : IResponse
{  }
