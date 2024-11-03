using FluentValidation;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.DTOs.Customer.Updated;
using SalesService.Application.Requests.Common;
using SalesService.Application.Validations.Common;

namespace SalesService.Application.Requests.Customer;

public record UpdateCustomerRequest(UpdateCustomerDto UpdateCustomerDto) : IUpdateRequest
{
    public Guid Id { get; set; }
}

public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerRequestValidator()
    {
        RuleFor(x => x.UpdateCustomerDto)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(UpdateCustomerDto)));
        
        RuleFor(x => x.UpdateCustomerDto.Name)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(UpdateCustomerDto.Name)))
            .Length(3, 50).WithMessage($"{nameof(CreateCustomerDto.Name)} must be between 2 and 50 characters.");

        RuleFor(x => x.UpdateCustomerDto.Email)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(UpdateCustomerDto.Email)))
            .EmailAddress().WithMessage(ValidatorHelper.RuleMessage_InvalidEmail());
    }
}