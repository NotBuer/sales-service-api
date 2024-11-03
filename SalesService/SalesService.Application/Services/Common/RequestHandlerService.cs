using AutoMapper;
using FluentValidation;
using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Common;
using SalesService.Domain.Interfaces.Repository;
using SalesService.Domain.Validations;
using SalesService.Infrastructure.UnitOfWork;

namespace SalesService.Application.Services.Common;

public class RequestHandlerService<TRequest, TContent, TEntity>(
    IWriteRepository<TEntity> repository,
    IValidator<TRequest> validator,
    IMapper mapper,
    IUnitOfWork unitOfWork) : 
    IRequestHandlerService<TRequest, TContent, TEntity>
    where TRequest : IRequest
    where TContent : class
    where TEntity : class
{
    
    public async Task<RequestHandlerContent<TContent>> AddAsync(
        TRequest request,
        ValidationResult validationResult,
        CancellationToken cancellationToken)
    {
        validationResult.AddFluentValidationResult(await validator.ValidateAsync(request, cancellationToken));
        if (!validationResult.IsValid) return new RequestHandlerContent<TContent>(validationResult);
        
        await unitOfWork.BeginAsync(cancellationToken);

        var entity = mapper.Map<TEntity>(request);
        var content = mapper.Map<TContent>(await repository.AddAsync(entity, cancellationToken));
        
        await unitOfWork.CommitAsync(cancellationToken);
        
        return new RequestHandlerContent<TContent>(validationResult, content);
    }

    public Task<RequestHandlerContent<TContent>> UpdateAsync(
        TRequest request,
        ValidationResult validationResult,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<RequestHandlerContent<TContent>> DeleteAsync(
        TRequest request,
        ValidationResult validationResult,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}