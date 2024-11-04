using SalesService.Application.Responses.Common;

namespace SalesService.Application.Responses.Inventory.Product;

public sealed class ProductCreatedResponse<TContent> : Response<TContent>
    where TContent : class
{
    public ProductCreatedResponse() { }

    public ProductCreatedResponse(
        TContent content,
        Metadata metadata)
    {
        Content = content;
        Metadata = metadata;
    }
    
    public override TContent? Content { get; init; }
    public override Metadata Metadata { get; init; }
}