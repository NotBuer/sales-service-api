using SalesService.Application.DTOs.Customer;
using SalesService.Application.Responses.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Responses;

public record CustomerCreatedResponse : IResponse
{
    public CustomerCreatedResponse() {}
    
    public CustomerCreatedResponse(
        Metadata metadata,
        object content,
        ValidationResult validationResult)
    {
        Metadata = metadata;
        Content = content;
        ValidationResult = validationResult;
    }

    public Metadata Metadata { get; init; }
    public object Content { get; init; }
    public ValidationResult ValidationResult { get; init; }
}