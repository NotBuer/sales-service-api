using SalesService.Application.DTOs.Inventory.Product;
using SalesService.Application.Responses.Inventory.Product;

namespace SalesService.API.Endpoints.Inventory;

internal static partial class Product
{
    internal static void Map(WebApplication app)
    {
        app.MapPost("product", Post)
            .Produces<ProductCreatedResponse<ProductDto>>(StatusCodes.Status201Created)
            .WithMetadata(new ResponseMetadataProvider());
    }
}