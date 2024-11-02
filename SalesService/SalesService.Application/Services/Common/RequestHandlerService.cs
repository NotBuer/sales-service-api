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
    
    public async Task<RequestHandlerContent> AddAsync(
        TRequest request,
        ValidationResult validationResult,
        CancellationToken cancellationToken)
    {
        validationResult.AddFluentValidationResult(await validator.ValidateAsync(request, cancellationToken));
        if (!validationResult.IsValid) return RequestHandlerContent.NoContent(validationResult);
        
        await unitOfWork.BeginAsync(cancellationToken);

        var entity = mapper.Map<TEntity>(request);
        var content = await repository.AddAsync(entity, cancellationToken);
        
        await unitOfWork.CommitAsync(cancellationToken);
        
        return RequestHandlerContent.WithContent(validationResult, content);
    }

    public Task<RequestHandlerContent> UpdateAsync(
        TRequest request,
        ValidationResult validationResult,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<RequestHandlerContent> DeleteAsync(
        TRequest request,
        ValidationResult validationResult,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}