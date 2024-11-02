using AutoMapper;
using FluentValidation;
using SalesService.Application.Requests.Common;
using SalesService.Domain.Interfaces.Repository;
using SalesService.Domain.Validations;
using SalesService.Infrastructure.UnitOfWork;

namespace SalesService.Application.Services.Common;

public class RequestHandlerService<TRequest, TEntity>(
    IWriteRepository<TEntity> repository,
    IValidator<TRequest> validator,
    IMapper mapper,
    IUnitOfWork unitOfWork) : 
    IRequestHandlerService<TRequest, TEntity>
    where TRequest : IRequest
    where TEntity : class
{
    
    public async Task<ValidationResult> AddAsync(
        TRequest request,
        ValidationResult validationResult,
        CancellationToken cancellationToken)
    {
        validationResult.AddFluentValidationResult(await validator.ValidateAsync(request, cancellationToken));
        if (!validationResult.IsValid) return validationResult;
        
        await unitOfWork.BeginAsync(cancellationToken);

        var entity = mapper.Map<TEntity>(request);
        await repository.AddAsync(entity, cancellationToken);
        
        await unitOfWork.CommitAsync(cancellationToken);
        
        
        
        return validationResult;
    }

    public Task<ValidationResult> UpdateAsync(
        TRequest request,
        ValidationResult validationResult,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ValidationResult> DeleteAsync(
        TRequest request,
        ValidationResult validationResult,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}