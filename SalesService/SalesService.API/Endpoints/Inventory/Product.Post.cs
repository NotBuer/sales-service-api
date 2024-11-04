using SalesService.Application.DTOs.Inventory.Product;
using SalesService.Application.Requests.Inventory.Product;
using SalesService.Application.Responses.Inventory.Product;

namespace SalesService.API.Endpoints.Inventory;

internal static partial class Product
{
    private static async Task<IResult> Post(
        IAddCommandHandler<
            CreateProductRequest,
            ProductCreatedResponse<ProductDto>,
            ProductDto,
            Domain.Entities.Inventory.Product> commandHandler,
        CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var response = await commandHandler.Handle(request, cancellationToken);
        return Result.From(new { response.Content, response.Metadata }, new());
    }
}