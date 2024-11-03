using FluentValidation;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.Requests.Common;
using SalesService.Application.Validations.Common;

namespace SalesService.Application.Requests.Customer;

public record UpdateCustomerRequest(CustomerDto CustomerDto) : IUpdateRequest
{
    public Guid Id { get; set; }
}

public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerRequestValidator()
    {
        RuleFor(x => x.CustomerDto)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(CustomerDto)));
        
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(UpdateCustomerRequest.Id)));
        
        RuleFor(x => x.CustomerDto.Name)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(CustomerDto.Name)))
            .Length(3, 50).WithMessage($"{nameof(CustomerDto.Name)} must be between 3 and 50 characters.");

        RuleFor(x => x.CustomerDto.Email)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(CustomerDto.Email)))
            .EmailAddress().WithMessage(ValidatorHelper.RuleMessage_InvalidEmail());
    }
}