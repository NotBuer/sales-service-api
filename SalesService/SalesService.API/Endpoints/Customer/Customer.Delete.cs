using SalesService.Application.Requests.Customer;
using SalesService.Application.Responses.Customer;

namespace SalesService.API.Endpoints.Customer;

internal static partial class Customer
{
    private static async Task<IResult> Delete(
        IDeleteCommandHandler<
            DeleteCustomerRequest,
            CustomerDeletedResponse<object>,
            object,
            Domain.Entities.Customer.Customer> commandHandler,
        Guid id,
        CancellationToken cancellationToken)
    {
        var response = await commandHandler.Handle(new DeleteCustomerRequest(id), cancellationToken);
        return Result.From(new { response.Content, response.Metadata }, new());
    }
}