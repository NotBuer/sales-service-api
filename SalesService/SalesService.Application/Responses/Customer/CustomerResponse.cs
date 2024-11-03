using SalesService.Application.Responses.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Responses.Customer;

public sealed class CustomerResponse<TContent> : Response<TContent>
    where TContent : class
{
    public CustomerResponse() { }

    public CustomerResponse(
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