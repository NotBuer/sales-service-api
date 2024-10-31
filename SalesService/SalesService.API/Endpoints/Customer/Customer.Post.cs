using SalesService.Application.Commands.Common;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.Requests.Common;
using SalesService.Application.Responses;
using SalesService.Application.Responses.Common;

namespace SalesService.API.Endpoints.Customer;

internal static partial class Customer
{
    internal static Task<IResult> Post(
        ICommandHandler<IAddRequest, CustomerCreatedResponse> handler,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}