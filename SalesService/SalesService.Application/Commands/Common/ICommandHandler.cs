using SalesService.Application.Requests.Common;

namespace SalesService.Application.Commands.Common;

public interface ICommandHandler<TRequest, TResponse>
    where TRequest: class
{
    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

public interface IAddCommandHandler<TRequest, TResponse, TDto, TEntity> : ICommandHandler<TRequest, TResponse> where TRequest: class, IAddRequest {  }
public interface IUpdateCommandHandler<TRequest, TResponse, TDto, TEntity> : ICommandHandler<TRequest, TResponse> where TRequest: class, IUpdateRequest {  }
public interface IDeleteCommandHandler<TRequest, TResponse, TDto, TEntity> : ICommandHandler<TRequest, TResponse> where TRequest: class, IDeleteRequest {  }