using Microsoft.AspNetCore.Mvc;
using SalesService.Application.DTOs.Customer.Updated;
using SalesService.Application.Requests.Customer;
using SalesService.Application.Responses.Customer;

namespace SalesService.API.Endpoints.Customer;

internal static partial class Customer
{
    private static async Task<IResult> Put(
        IUpdateCommandHandler<
            UpdateCustomerRequest,
            CustomerUpdatedResponse<CustomerUpdatedDto>,
            CustomerUpdatedDto,
            Domain.Entities.Customer.Customer> commandHandler,
        UpdateCustomerRequest request,
        CancellationToken cancellationToken)
    {
        var response = await commandHandler.Handle(request, cancellationToken);
        return Result.From(new { response.Content, response.Metadata }, response.ValidationResult);
    }
}