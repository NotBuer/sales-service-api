using FluentValidation;
using SalesService.Application.Requests.Common;

namespace SalesService.Application.Validations.Common;

public class RequestValidator<TRequest> : AbstractValidator<TRequest>
    where TRequest : IRequest
{
    
}