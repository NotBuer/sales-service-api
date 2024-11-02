using SalesService.Domain.Validations;

namespace SalesService.Application.Services.Common;

public struct RequestHandlerContent
{
    private RequestHandlerContent(ValidationResult validationResult, object? content = null)
    {
        ValidationResult = validationResult;
        Content = content;
    }
    
    public ValidationResult ValidationResult { get; init; }
    public object? Content { get; init; }

    public static RequestHandlerContent NoContent(
        ValidationResult validationResult) =>
        new(validationResult);
    
    public static RequestHandlerContent WithContent(
        ValidationResult validationResult,
        object? content) =>
        new(validationResult, content);
}