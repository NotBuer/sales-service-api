using SalesService.Application.DTOs.Customer;
using SalesService.Application.Requests.Customer;
using SalesService.Application.Responses.Customer;

namespace SalesService.API.Endpoints.Customer;

internal static partial class Customer
{
    private static async Task<IResult> Put(
        IUpdateCommandHandler<
            UpdateCustomerRequest,
            CustomerUpdatedResponse<CustomerDto>,
            CustomerDto,
            Domain.Entities.Customer.Customer> commandHandler,
        UpdateCustomerRequest request,
        CancellationToken cancellationToken)
    {
        var response = await commandHandler.Handle(request, cancellationToken);
        return Result.From(new { response.Content, response.Metadata }, new());
    }
}