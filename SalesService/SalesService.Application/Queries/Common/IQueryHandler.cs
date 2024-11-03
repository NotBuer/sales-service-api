using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;

namespace SalesService.Application.Queries.Common;

public interface IQueryHandler<TRequest, TResponse, TContent, TEntity>
    where TRequest: IRequest
    where TResponse: Response<TContent>, new()
    where TContent: class
    where TEntity : class
{
    public Task<TResponse> Handle(TRequest request, CancellationToken token);
}

public interface IGetByIdQueryHandler<TRequest, TResponse, TContent, TEntity> : IQueryHandler<TRequest, TResponse, TContent, TEntity>
    where TRequest : IGetByIdRequest 
    where TResponse : Response<TContent>, new()
    where TContent : class
    where TEntity : class;

public interface ISearchQueryHandler<TRequest, TResponse, TContent, TEntity> : IQueryHandler<TRequest, TResponse, TContent, TEntity>
    where TRequest : ISearchRequest
    where TResponse : Response<TContent>, new()
    where TContent : class
    where TEntity : class;
