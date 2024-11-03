using AutoMapper;
using FluentValidation;
using SalesService.Application.Requests.Common;
using SalesService.Domain.Interfaces.Repository;
using SalesService.Domain.Validations;
using SalesService.Infrastructure.UnitOfWork;

namespace SalesService.Application.Services.Common;

public class RequestHandlerService<TRequest, TContent, TEntity>(
    IRepository<TEntity> repository,
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
        
        var content = mapper.Map<TContent>(await repository.AddAsync(mapper.Map<TEntity>(request), cancellationToken));
        
        await unitOfWork.CommitAsync(cancellationToken);
        
        return new RequestHandlerContent<TContent>(validationResult, content);
    }

    public async Task<RequestHandlerContent<TContent>> UpdateAsync(
        TRequest request,
        ValidationResult validationResult,
        CancellationToken cancellationToken)
    {
        validationResult.AddFluentValidationResult(await validator.ValidateAsync(request, cancellationToken));
        if (!validationResult.IsValid) return new RequestHandlerContent<TContent>(validationResult);
        
        await unitOfWork.BeginAsync(cancellationToken);
        
        var entity = await repository.GetByIdAsync(((IUpdateRequest)request).Id, false, cancellationToken);
        if (entity is null) return new RequestHandlerContent<TContent>(validationResult);

        var content = mapper.Map<TContent>(await repository.UpdateAsync(mapper.Map(request, entity), cancellationToken));

        await unitOfWork.CommitAsync(cancellationToken);
        
        return new RequestHandlerContent<TContent>(validationResult, content);
    }

    public async Task<RequestHandlerContent<TContent>> DeleteAsync(
        TRequest request,
        ValidationResult validationResult,
        CancellationToken cancellationToken)
    {
        validationResult.AddFluentValidationResult(await validator.ValidateAsync(request, cancellationToken));
        if (!validationResult.IsValid) return new RequestHandlerContent<TContent>(validationResult);
        
        await unitOfWork.BeginAsync(cancellationToken);

        var entity = await repository.GetByIdAsync(((IDeleteRequest)request).Id, false, cancellationToken);
        if (entity is null) return new RequestHandlerContent<TContent>(validationResult);

        await repository.DeleteAsync(mapper.Map(request, entity), cancellationToken);
        
        await unitOfWork.CommitAsync(cancellationToken);
        
        return new RequestHandlerContent<TContent>(validationResult, null);
    }
}