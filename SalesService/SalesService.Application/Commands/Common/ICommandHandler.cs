using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;

namespace SalesService.Application.Commands.Common;

public interface ICommandHandler<TRequest, TResponse, TContent>
    where TRequest: IRequest
    where TResponse: Response<TContent>, new()
    where TContent: class
{
    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

public interface
    IAddCommandHandler<TRequest, TResponse, TContent, TEntity> : ICommandHandler<TRequest, TResponse, TContent>
    where TRequest : IAddRequest
    where TResponse : Response<TContent>, new()
    where TContent : class
    where TEntity : class;

public interface
    IUpdateCommandHandler<TRequest, TResponse, TContent, TEntity> : ICommandHandler<TRequest, TResponse, TContent>
    where TRequest : IUpdateRequest
    where TResponse : Response<TContent>, new()
    where TContent : class
    where TEntity : class;

public interface IDeleteCommandHandler<TRequest, TResponse, TContent, TEntity> : ICommandHandler<TRequest, TResponse, TContent> 
    where TRequest: IDeleteRequest 
    where TResponse : Response<TContent>, new()
    where TContent : class
    where TEntity : class;