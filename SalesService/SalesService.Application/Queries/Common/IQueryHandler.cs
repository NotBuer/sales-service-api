using SalesService.Application.Responses.Common;

namespace SalesService.Application.Queries.Common;

public interface IQueryHandler<TRequest, TResponse>
    where TRequest: class
{
    public Task<TResponse> Handle(TRequest request);
}

public interface IGetByIdQueryHandler<TRequest, TResponse> : IQueryHandler<TRequest, TResponse> where TRequest : class, IGetByIdRequest {  }
