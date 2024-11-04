using SalesService.Application.DTOs.Customer;
using SalesService.Application.Queries.Common;
using SalesService.Application.Requests.Common;
using SalesService.Application.Responses.Customer;

namespace SalesService.API.Endpoints.Customer;

internal static partial class Customer
{
    private static async Task<IResult> GetById(
        IGetByIdQueryHandler<
            IGetByIdRequest,
            CustomerResponse<CustomerDto>,
            CustomerDto,
            Domain.Entities.Customer.Customer> queryHandler,
        Guid id,
        CancellationToken cancellationToken)
    {
        var response = await queryHandler.Handle(new GetByIdRequest(id), cancellationToken);
        return Result.From(new { response.Content, response.Metadata }, new());
    }
}