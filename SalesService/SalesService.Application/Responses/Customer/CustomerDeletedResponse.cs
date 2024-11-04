using SalesService.Application.Responses.Common;

namespace SalesService.Application.Responses.Customer;

public sealed class CustomerDeletedResponse<TContent> : Response<TContent>
    where TContent : class
{
    public CustomerDeletedResponse() {}

    public CustomerDeletedResponse(
        TContent content,
        Metadata metadata)
    {
        Content = content;
        Metadata = metadata;
    }
    
    public override TContent? Content { get; init; }
    public override Metadata Metadata { get; init; }
}