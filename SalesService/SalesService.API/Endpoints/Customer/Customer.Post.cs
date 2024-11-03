using SalesService.Application.DTOs.Customer.Created;
using SalesService.Application.Requests.Common;

namespace SalesService.API.Endpoints.Customer;

internal static partial class Customer
{
    private static async Task<IResult> Post(
        IAddCommandHandler<
            CreateCustomerRequest,
            CustomerCreatedResponse<CustomerCreatedDto>,
            CustomerCreatedDto,
            Domain.Entities.Customer.Customer> commandHandler,
        CreateCustomerRequest request,
        CancellationToken cancellationToken)
    {
        var response = await commandHandler.Handle(request, cancellationToken);
        return Result.From(new { response.Metadata, response.Content }, response.ValidationResult);
    }
}