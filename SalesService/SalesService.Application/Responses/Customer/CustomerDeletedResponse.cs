using SalesService.Application.DTOs.Customer;
using SalesService.Application.Responses.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Responses.Customer;

public sealed class CustomerDeletedResponse<TContent> : Response<TContent>
    where TContent : class
{
    public CustomerDeletedResponse() {}

    public CustomerDeletedResponse(
        TContent content,
        Metadata metadata,
        ValidationResult validationResult)
    {
        Content = content;
        Metadata = metadata;
        ValidationResult = validationResult;
    }
    
    public override TContent? Content { get; init; }
    public override Metadata Metadata { get; init; }
    public override ValidationResult ValidationResult { get; init; }
}