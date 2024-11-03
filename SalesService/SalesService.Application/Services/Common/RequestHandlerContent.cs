using SalesService.Domain.Validations;

namespace SalesService.Application.Services.Common;

public struct RequestHandlerContent<TContent>
{
    public RequestHandlerContent(ValidationResult validationResult, TContent? content = default)
    {
        ValidationResult = validationResult;
        Content = content;
    }
    
    public ValidationResult ValidationResult { get; init; }
    public TContent? Content { get; init; }
}