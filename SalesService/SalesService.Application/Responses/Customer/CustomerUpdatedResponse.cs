using SalesService.Application.Responses.Common;

namespace SalesService.Application.Responses.Customer;

public sealed class CustomerUpdatedResponse<TContent> : Response<TContent>
    where TContent : class
{
    public CustomerUpdatedResponse() {}

    public CustomerUpdatedResponse(
        TContent content,
        Metadata metadata)
    {
        Content = content;
        Metadata = metadata;
    }
    
    public override TContent? Content { get; init; }
    public override Metadata Metadata { get; init; }
}