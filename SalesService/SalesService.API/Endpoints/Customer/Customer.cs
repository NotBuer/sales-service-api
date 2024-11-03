using SalesService.Application.DTOs.Customer.Created;
using SalesService.Application.DTOs.Customer.Updated;
using SalesService.Application.Responses.Customer;

namespace SalesService.API.Endpoints.Customer;

internal static partial class Customer
{
    internal static void Map(WebApplication app)
    {
        app.MapPost("customer", Post)
            .Produces<CustomerCreatedResponse<CustomerCreatedDto>>(StatusCodes.Status201Created)
            .WithMetadata(new ResponseMetadataProvider());

        app.MapPut("customer", Put)
            .Produces<CustomerUpdatedResponse<CustomerUpdatedDto>>()
            .WithMetadata(new ResponseMetadataProvider());
    }
}