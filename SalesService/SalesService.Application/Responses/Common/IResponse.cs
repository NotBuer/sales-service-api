using SalesService.Domain.Validations;

namespace SalesService.Application.Responses.Common;

public interface IResponse
{
    public Metadata Metadata { get; init; }
    public object Content { get; init; }
    public ValidationResult ValidationResult { get; init; }
}

public record Metadata(string? Status, string? Message, DateTime Timestamp);