using SalesService.Application.DTOs.Customer.Created;
using SalesService.Application.Responses;

namespace SalesService.API.Endpoints.Customer;

internal static partial class Customer
{
    internal static void Map(WebApplication app)
    {
        app.MapPost("customer", Post)
            .Produces<CustomerCreatedResponse<CustomerCreatedDto>>(StatusCodes.Status201Created)
            .WithMetadata(new ResponseMetadataProvider());
    }
}