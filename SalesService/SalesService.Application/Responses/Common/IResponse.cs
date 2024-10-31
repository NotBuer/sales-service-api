namespace SalesService.Application.Responses.Common;

public interface IResponse
{
    public MetaData MetaData { get; init; }
}

public record MetaData(string? Status, string? Message, DateTime Timestamp);