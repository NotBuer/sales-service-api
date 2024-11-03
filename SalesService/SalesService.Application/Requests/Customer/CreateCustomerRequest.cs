using FluentValidation;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.Requests.Common;
using SalesService.Application.Validations.Common;

namespace SalesService.Application.Requests.Customer;

public record CreateCustomerRequest(CreateCustomerDto CreateCustomerDto) : IAddRequest;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(x => x.CreateCustomerDto)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(CreateCustomerDto)));
        
        RuleFor(x => x.CreateCustomerDto.Name)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(CreateCustomerDto.Name)))
            .Length(3, 50).WithMessage($"{nameof(CreateCustomerDto.Name)} must be between 2 and 50 characters.");
        
        RuleFor(x => x.CreateCustomerDto.Email)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(CreateCustomerDto.Email)))
            .EmailAddress().WithMessage(ValidatorHelper.RuleMessage_InvalidEmail());
    }
}