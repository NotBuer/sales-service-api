using SalesService.Application.Responses.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Responses;

public sealed class CustomerCreatedResponse<TContent> : Response<TContent>
    where TContent : class
{
    public CustomerCreatedResponse() {}
    
    public CustomerCreatedResponse(
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