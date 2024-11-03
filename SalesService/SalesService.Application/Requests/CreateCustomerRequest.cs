using FluentValidation;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.Requests.Common;

namespace SalesService.Application.Requests;

public record CreateCustomerRequest(CreateCustomerDto CreateCustomerDto) : IAddRequest;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(x => x.CreateCustomerDto)
            .NotNull().WithMessage(x => $"Object property {nameof(CreateCustomerDto)} cannot be null.");
        
        RuleFor(x => x.CreateCustomerDto.Name)
            .NotEmpty().WithMessage(x => $"{nameof(CreateCustomerDto.Name)} is required.")
            .Length(3, 50).WithMessage($"{nameof(CreateCustomerDto.Name)} must be between 2 and 50 characters.");
        
        RuleFor(x => x.CreateCustomerDto.Email)
            .NotEmpty().WithMessage($"{nameof(CreateCustomerDto.Email)} is required.")
            .EmailAddress().WithMessage("Valid email address is required.");
    }
}