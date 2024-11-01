using SalesService.Application.DTOs.Customer;
using SalesService.Application.Responses.Common;
using SalesService.Domain.Validations;

namespace SalesService.Application.Responses;

public record CustomerCreatedResponse(Metadata Metadata, CustomerDto CustomerDto, ValidationResult ValidationResult) : IResponse
{
    public CustomerDto? CustomerDto { get; init; } = CustomerDto;
}