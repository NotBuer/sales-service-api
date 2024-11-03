using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;

namespace SalesService.Application.Commands.Common;

public interface ICommandHandler<in TRequest, TResponse, TContent>
    where TRequest: IRequest
    where TResponse: Response<TContent>, new()
    where TContent: class
{
    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TRequest>
    where TRequest : IRequest
{
    public Task Handle(TRequest request, CancellationToken cancellationToken);
}

public interface IAddCommandHandler<in TRequest, TResponse, TContent, TEntity> : ICommandHandler<TRequest, TResponse, TContent>
    where TRequest : IAddRequest 
    where TResponse : Response<TContent>, new()
    where TContent : class;

public interface IUpdateCommandHandler<in TRequest, TResponse, TContent, TEntity> : ICommandHandler<TRequest, TResponse, TContent>
    where TRequest : IUpdateRequest 
    where TResponse : Response<TContent>, new()
    where TContent : class;

public interface IDeleteCommandHandler<in TRequest, TResponse, TContent, TEntity> : ICommandHandler<TRequest, TResponse, TContent> 
    where TRequest: IDeleteRequest 
    where TResponse : Response<TContent>, new()
    where TContent : class;