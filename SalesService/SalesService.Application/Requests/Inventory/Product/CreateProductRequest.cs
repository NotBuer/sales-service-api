using FluentValidation;
using SalesService.Application.DTOs.Inventory.Product;
using SalesService.Application.Requests.Common;
using SalesService.Application.Validations.Common;

namespace SalesService.Application.Requests.Inventory.Product;

public record CreateProductRequest(ProductDto ProductDto) : IAddRequest;

public class CreateUpdateRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateUpdateRequestValidator()
    {
        RuleFor(x => x.ProductDto)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(ProductDto)));
        
        RuleFor(x => x.ProductDto.Name)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(ProductDto.Name)));
        
        RuleFor(x => x.ProductDto.Price)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(ProductDto.Price)));

        RuleFor(x => x.ProductDto.Discount)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(ProductDto.Discount)));

        RuleFor(x => x.ProductDto.FinalPrice)
            .NotEmpty().WithMessage(ValidatorHelper.RuleMessage_CannotBeNullOrEmpty(nameof(ProductDto.FinalPrice)));
    }
}