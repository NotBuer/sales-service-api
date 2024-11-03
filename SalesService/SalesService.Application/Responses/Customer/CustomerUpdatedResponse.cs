using SalesService.Application.Responses.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Responses.Customer;

public sealed class CustomerUpdatedResponse<TContent> : Response<TContent>
    where TContent : class
{
    public CustomerUpdatedResponse() {}

    public CustomerUpdatedResponse(
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