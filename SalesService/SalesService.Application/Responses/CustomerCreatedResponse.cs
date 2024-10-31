using SalesService.Application.DTOs.Customer;
using SalesService.Application.Responses.Common;

namespace SalesService.Application.Responses;

public record CustomerCreatedResponse(MetaData MetaData, CustomerDto CustomerDto) : IResponse
{
    public CustomerDto? CustomerDto { get; init; } = CustomerDto;
}