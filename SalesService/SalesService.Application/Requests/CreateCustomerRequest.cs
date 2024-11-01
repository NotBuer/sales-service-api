using FluentValidation;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.Requests.Common;

namespace SalesService.Application.Requests;

public record CreateCustomerRequest(CustomerDto CustomerDto) : IAddRequest;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(x => x.CustomerDto)
            .NotNull().WithMessage(x => $"Object property {nameof(CustomerDto)} cannot be null.");
        
        RuleFor(x => x.CustomerDto.Name)
            .NotEmpty().WithMessage(x => $"{nameof(CustomerDto.Name)} is required.")
            .Length(3, 50).WithMessage($"{nameof(CustomerDto.Name)} must be between 2 and 50 characters.");
        
        RuleFor(x => x.CustomerDto.Email)
            .NotEmpty().WithMessage($"{nameof(CustomerDto.Email)} is required.")
            .EmailAddress().WithMessage("Valid email address is required.");
        
    }
}