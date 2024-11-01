using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;

namespace SalesService.Application.Commands.Common;

public interface ICommandHandler<TRequest, TResponse>
    where TRequest: IRequest
    where TResponse: IResponse
{
    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

public interface ICommandHandler<TRequest>
    where TRequest : IRequest
{
    public Task Handle(TRequest request, CancellationToken cancellationToken);
}

public interface IAddCommandHandler<TRequest, TResponse, TEntity> : ICommandHandler<TRequest, TResponse>
    where TRequest : IAddRequest where TResponse : IResponse;

public interface IUpdateCommandHandler<TRequest, TResponse, TEntity> : ICommandHandler<TRequest, TResponse>
    where TRequest : IUpdateRequest where TResponse : IResponse;

public interface IDeleteCommandHandler<TRequest, TResponse, TEntity> : ICommandHandler<TRequest, TResponse> 
    where TRequest: IDeleteRequest where TResponse : IResponse;