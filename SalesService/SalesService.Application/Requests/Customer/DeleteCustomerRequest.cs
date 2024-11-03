using FluentValidation;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.Requests.Common;
using SalesService.Application.Validations.Common;

namespace SalesService.Application.Requests.Customer;

public record DeleteCustomerRequest() : IDeleteRequest
{
    public Guid Id { get; set; }
}

public class DeleteCustomerRequestValidator : AbstractValidator<DeleteCustomerRequest>
{
    public DeleteCustomerRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(DeleteCustomerRequest.Id)));
    }
}