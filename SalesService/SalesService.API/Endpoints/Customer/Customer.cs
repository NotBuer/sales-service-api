using SalesService.Application.DTOs.Customer;
using SalesService.Application.Responses.Customer;

namespace SalesService.API.Endpoints.Customer;

internal static partial class Customer
{
    internal static void Map(WebApplication app)
    {
        app.MapGet("customer/{id}", GetById)
            .Produces<CustomerResponse<CustomerDto>>()
            .WithMetadata(new ResponseMetadataProvider());
        
        app.MapPost("customer", Post)
            .Produces<CustomerCreatedResponse<CustomerDto>>(StatusCodes.Status201Created)
            .WithMetadata(new ResponseMetadataProvider());

        app.MapPut("customer", Put)
            .Produces<CustomerUpdatedResponse<CustomerDto>>()
            .WithMetadata(new ResponseMetadataProvider());
        
        app.MapDelete("customer/{id}", Delete)
            .Produces<CustomerDeletedResponse<object>>()
            .WithMetadata(new ResponseMetadataProvider());
    }
}