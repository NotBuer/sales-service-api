using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;
using SalesService.Application.Services.Common;

namespace SalesService.Application.Commands.Common;

/// <summary>
/// CommandHandler intended to: <br />
/// - Inject the <see cref="RequestHandlerService{TRequest,TEntity}"/> to handle the incoming request. <br />
/// - Receive the Content and ValidationResult from the <see cref="RequestHandlerService{TRequest,TEntity}"/>. <br />
/// - Construct the response object and return it.
/// </summary>
public interface ICommandHandler<TRequest, TResponse>
    where TRequest: IRequest
    where TResponse: IResponse, new()
{
    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// CommandHandler intended to: <br />
/// - Inject the <see cref="RequestHandlerService{TRequest,TEntity}"/> to handle the incoming request. <br />
/// - Return nothing.
/// </summary>
public interface ICommandHandler<TRequest>
    where TRequest : IRequest
{
    public Task Handle(TRequest request, CancellationToken cancellationToken);
}

public interface IAddCommandHandler<TRequest, TResponse, TEntity> : ICommandHandler<TRequest, TResponse>
    where TRequest : IAddRequest where TResponse : IResponse, new();

public interface IUpdateCommandHandler<TRequest, TResponse, TEntity> : ICommandHandler<TRequest, TResponse>
    where TRequest : IUpdateRequest where TResponse : IResponse, new();

public interface IDeleteCommandHandler<TRequest, TResponse, TEntity> : ICommandHandler<TRequest, TResponse> 
    where TRequest: IDeleteRequest where TResponse : IResponse, new();