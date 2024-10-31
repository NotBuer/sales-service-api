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

public interface IAddCommandHandler<TRequest, TResponse, TDto, TEntity> : ICommandHandler<TRequest, TResponse> where TRequest: class, IAddRequest where TResponse : IResponse
{  }
public interface IUpdateCommandHandler<TRequest, TResponse, TDto, TEntity> : ICommandHandler<TRequest, TResponse> where TRequest: class, IUpdateRequest where TResponse : IResponse
{  }
public interface IDeleteCommandHandler<TRequest, TResponse, TDto, TEntity> : ICommandHandler<TRequest, TResponse> where TRequest: class, IDeleteRequest where TResponse : IResponse
{  }