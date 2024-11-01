using AutoMapper;
using FluentValidation;
using SalesService.Application.Requests.Common;
using SalesService.Domain.Interfaces.Repository;
using SalesService.Domain.Validations;

namespace SalesService.Application.Services.Common;

public class RequestHandlerService<TRequest, TEntity>(
    IWriteRepository<TEntity> repository,
    IValidator<TRequest> validator,
    IMapper mapper,
    ValidationResult validationResult) : 
    IRequestHandlerService<TRequest, TEntity>
    where TRequest : IRequest
    where TEntity : class 
{
    public async Task<ValidationResult> AddAsync(TRequest request, CancellationToken cancellationToken)
    {
        validationResult.AddFluentValidationResult(await validator.ValidateAsync(request, cancellationToken));
        if (!validationResult.IsValid) return validationResult;

        var destinationEntity = mapper.Map<TEntity>(request);
        await repository.AddAsync(destinationEntity, cancellationToken);
        
        return validationResult;
    }

    public Task<ValidationResult> UpdateAsync(TRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ValidationResult> DeleteAsync(TRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}